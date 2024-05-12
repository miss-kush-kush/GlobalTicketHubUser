using DLL.DbContext;
using Domain.Entities.LocationEntities;
using Domain.Entities.BusEntities;
using BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Numerics;
using System.Security.Policy;
using static System.Collections.Specialized.BitVector32;
using Microsoft.Extensions.Hosting;
using Domain.Types;
using DLL.Dtos.BusDtos;
using DLL.Dtos.TrainDtos;
using Domain.BusEntities;
using Domain.Entities.UserEntities;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Net.Mail;
using System.Net;

public class BusService : IBusService
{
    private readonly AppDbContext _context;

    public BusService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AppropriateBusLineDto>> FindAppropriateLinesAsync(string departureStation, string arrivalStation, DateTime departureDate)
    {
        int departureStationId = _context.BusStations.FirstOrDefault(bs => bs.StationName == departureStation)?.Id ?? -1;
        int arrivalStationId = _context.BusStations.FirstOrDefault(bs => bs.StationName == arrivalStation)?.Id ?? -1;

        if (departureStationId == -1 || arrivalStationId == -1)
        {
            return Enumerable.Empty<AppropriateBusLineDto>();
        }

        var departureMovements = await _context.BusMovements
            .Include(bm => bm.BusLine)
            .ThenInclude(bl => bl.Buses)
            .ThenInclude(b => b.BusSeats)
            .Where(bm => bm.DepartureTime.HasValue &&
                         bm.DepartureTime.Value.Date == departureDate.Date &&
                         bm.BusStationId == departureStationId &&
                         bm.BusLine.Buses.Any(b => b.IsAvailable))
            .ToListAsync();

        var arrivalMovements = await _context.BusMovements
            .Include(bm => bm.BusLine)
            .ThenInclude(bl => bl.Buses)
            .ThenInclude(b => b.BusSeats)
            .Where(bm => bm.ArrivalTime.HasValue &&
                         bm.ArrivalTime.Value.Date == departureDate.Date &&
                         bm.BusStationId == arrivalStationId)
            .ToListAsync();

        var appropriateLines = from departureMovement in departureMovements
                               join arrivalMovement in arrivalMovements
                               on departureMovement.BusLineId equals arrivalMovement.BusLineId
                               where departureMovement.DepartureTime < arrivalMovement.ArrivalTime
                               select new AppropriateBusLineDto
                               {
                                   DepartureStation = departureStation,
                                   ArrivalStation = arrivalStation,
                                   DepartureTime = new TimeOnly(departureMovement.DepartureTime.Value.Hour, departureMovement.DepartureTime.Value.Minute),
                                   ArrivalTime = new TimeOnly(arrivalMovement.ArrivalTime.Value.Hour, arrivalMovement.ArrivalTime.Value.Minute),
                                   DepartureDate = departureMovement.DepartureTime.Value.Date,
                                   ArrivalDate = arrivalMovement.ArrivalTime.Value.Date,
                                   AvailablePlaces = departureMovement.BusLine.Buses.SelectMany<Bus, BusSeat>(b => b.BusSeats).Count(s => s.StateType == StateType.empty),
                                   TotalPlaces = departureMovement.BusLine.Buses.SelectMany<Bus, BusSeat>(b => b.BusSeats).Count(),
                                   Duration = GetDurationAsTimeOnly(departureMovement.DepartureTime.Value, arrivalMovement.ArrivalTime.Value),
                                   BusLineName = departureMovement.BusLine.LineName,
                                   BusLineDescription = departureMovement.BusLine.Description,
                                   BusId = departureMovement.BusLine.Buses.FirstOrDefault()?.Id ?? -1,
                                   BusNumber = departureMovement.BusLine.Buses.FirstOrDefault()?.BusNumber ?? string.Empty,
                                   FirstPrices = CalculateFirstPrices(departureMovement.DistanceFromStart, arrivalMovement.DistanceFromStart)
                               };

        return appropriateLines.ToList();
    }


    private List<decimal> CalculateFirstPrices(int departureDistance, int arrivalDistance)
    {
        var distance = arrivalDistance - departureDistance;
        var prices = new List<decimal>
        {
            (decimal)(distance * 5 * 0.05), // Economy
            (decimal)(distance * 5 * 0.2),  // FirstClass
            (decimal)(distance * 5 * 0.1)   // SecondClass
        };
        return prices;
    }

    private TimeOnly GetDurationAsTimeOnly(DateTime departureTime, DateTime arrivalTime)
    {
        var duration = arrivalTime - departureTime;
        int totalMinutes = (int)duration.TotalMinutes;
        int hours = totalMinutes / 60;
        int minutes = totalMinutes % 60;
        return new TimeOnly(hours, minutes);
    }

    public async Task<BusLineDto> GetBusDetailsByBusNumberAsync(string busLineName, int busId)
    {
        var busLine = await _context.BusLines
            .Where(bl => bl.LineName == busLineName)
            .Select(bl => new BusLineDto
            {
                LineName = bl.LineName,
                Description = bl.Description,
                Buses = bl.Buses
                    .Where(b => b.IsAvailable && b.Id == busId)
                    .Select(b => new BusDto
                    {
                        BusId = b.Id,
                        BusType = b.BusType,
                        Seats = b.BusSeats
                            .Where(s => s.StateType == StateType.empty)
                            .Select(s => new BusSeatDto
                            {
                                Number = s.Number,
                                SeatId = s.Id,
                                StateType = s.StateType
                            }).ToList()
                    }).ToList()
            })
            .FirstOrDefaultAsync();

        return busLine ?? throw new Exception("Bus line not found.");
    }

    public async Task ReserveSeats(SeatReservationRequestDto request)
    {
        var seats = await _context.BusSeats
            .Include(s => s.Bus)
            .Where(s => s.Bus.Id == request.BusId &&
                        request.SeatNumbers.Contains(s.Number) &&
                        s.StateType == StateType.empty)
            .ToListAsync();

        foreach (var seat in seats)
        {
            seat.StateType = StateType.bought;
        }
        await _context.SaveChangesAsync();
    }

    public async Task BuyBusTicketFail(PaymentBusResponseFailDto paymentResponseFailDto)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(o => o.OrderId == paymentResponseFailDto.OrderId);

        if (order != null)
        {
            throw new Exception($"Order with OrderId {paymentResponseFailDto.OrderId} already exists.");
        }
        else
        {
            order = new Order
            {
                OrderId = paymentResponseFailDto.OrderId,
                OrderState = paymentResponseFailDto.OrderStatus
            };

            await _context.Orders.AddAsync(order);
        }

        var seats = await _context.BusSeats
            .Include(s => s.Bus)
            .Where(s => s.Bus.Id == paymentResponseFailDto.BusId &&
                        paymentResponseFailDto.Seats.Contains(s.Number))
            .ToListAsync();

        foreach (var seat in seats)
        {
            seat.StateType = StateType.empty;
        }

        await _context.SaveChangesAsync();
    }

    public async Task BuyBusTicketSuccess(PaymentBusResponseSuccessDto paymentBusResponseSuccessDto)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(o => o.OrderId == paymentBusResponseSuccessDto.OrderId);

        if (order != null)
        {
            throw new Exception($"Order with OrderId {paymentBusResponseSuccessDto.OrderId} already exists.");
        }
        else
        {
            order = new Order
            {
                OrderId = paymentBusResponseSuccessDto.OrderId,
                OrderState = paymentBusResponseSuccessDto.OrderStatus
            };
            await _context.Orders.AddAsync(order);
        }

        var busTickets = new List<BusTicket>();
        var purchaseHistories = new List<BusPurchaseHistory>();
        var now = DateTime.UtcNow;

        foreach (var ticketDto in paymentBusResponseSuccessDto.BusTicketDtos)
        {
            var seat = await _context.BusSeats
                .Include(s => s.Bus)
                .FirstOrDefaultAsync(s => s.Bus.Id == paymentBusResponseSuccessDto.BusId &&
                                          s.Number == ticketDto.SeatNumber);

            if (seat == null)
            {
                throw new Exception($"Seat number {ticketDto.SeatNumber} not found.");
            }

            seat.StateType = StateType.bought;

            var busTicket = new BusTicket
            {
                Email = ticketDto.Email,
                FirstName = ticketDto.FirstName,
                LastName = ticketDto.LastName,
                Price = ticketDto.Price,
                DateOfPurchase = now,
                TicketType = ticketDto.TicketType,
                SeatNumber = ticketDto.SeatNumber,
                BusNumber = paymentBusResponseSuccessDto.BusId.ToString(),
                BusLineName = paymentBusResponseSuccessDto.BusLineName,
                TimeOfDeparture = paymentBusResponseSuccessDto.TimeOfDeparture,
                TimeOfArrival = paymentBusResponseSuccessDto.TimeOfArrival,
                StationOfDeparture = paymentBusResponseSuccessDto.StationOfDeparture,
                StationOfArrival = paymentBusResponseSuccessDto.StationOfArrival
            };

            await _context.BusTickets.AddAsync(busTicket);
            busTickets.Add(busTicket);

            if (!string.IsNullOrEmpty(ticketDto.UserId))
            {
                var purchaseHistory = new BusPurchaseHistory
                {
                    OrderId = order.Id,
                    UserId = ticketDto.UserId,
                    BusTicket = busTicket,
                    Price = busTicket.Price,
                    PurchaseDate = now
                };

                purchaseHistories.Add(purchaseHistory);
                await _context.BusPurchaseHistory.AddAsync(purchaseHistory);
            }

            SendTicketPdfByEmail(busTicket);
        }

        await _context.SaveChangesAsync();
    }

    private void SendTicketPdfByEmail(BusTicket busTicket)
    {
        var pdfDocument = new PdfDocument();
        var page = pdfDocument.AddPage();
        var graphics = XGraphics.FromPdfPage(page);
        var font = new XFont("Verdana", 12);

        graphics.DrawString($"Bus Ticket", font, XBrushes.Black,
        new XRect(0, 0, page.Width, page.Height),
        XStringFormats.TopCenter);

        graphics.DrawString($"Name: {busTicket.FirstName} {busTicket.LastName}", font, XBrushes.Black,
            new XRect(20, 40, page.Width, page.Height),
        XStringFormats.TopLeft);

        graphics.DrawString($"Email: {busTicket.Email}", font, XBrushes.Black,
            new XRect(20, 60, page.Width, page.Height),
        XStringFormats.TopLeft);

        graphics.DrawString($"Bus Number: {busTicket.BusNumber}", font, XBrushes.Black,
            new XRect(20, 80, page.Width, page.Height),
        XStringFormats.TopLeft);

        graphics.DrawString($"Departure: {busTicket.StationOfDeparture} at {busTicket.TimeOfDeparture}", font, XBrushes.Black,
            new XRect(20, 100, page.Width, page.Height),
        XStringFormats.TopLeft);

        graphics.DrawString($"Arrival: {busTicket.StationOfArrival} at {busTicket.TimeOfArrival}", font, XBrushes.Black,
            new XRect(20, 120, page.Width, page.Height),
            XStringFormats.TopLeft);

        // Save PDF to memory stream
        using (var stream = new MemoryStream())
        {
            pdfDocument.Save(stream, false);

            var client = new SmtpClient("smtp.example.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("kushneryk.yelyzaveta@gmailcom", "vswm vphu lhoi vpvn"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("noreply@globaltickethub.com"),
                Subject = "Your Bus Ticket",
                Body = "Please find your bus ticket attached.",
                IsBodyHtml = true,
            };
            mailMessage.To.Add(busTicket.Email);
            mailMessage.Attachments.Add(new Attachment(new MemoryStream(stream.ToArray()), "BusTicket.pdf"));

            client.Send(mailMessage);
        }
    }
}
