using DLL.DbContext;
using Domain.Entities.TrainEntities;
using Microsoft.EntityFrameworkCore;
using DLL.Dtos.TrainDtos;
using Domain.Types;
using Domain.Entities.UserEntities;
using DLL.Dtos.UserDtos;
using DLL.Dtos.PaymentDtos;
using System.Drawing;
using System.Net.Mail;
using System.Net;
using System.Xml.Linq;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

public class TrainService : ITrainService
{

    private readonly AppDbContext _context;

    public TrainService(AppDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<AppropriateTrainLineDto>> FindAppropriateLinesAsync(string departureStation, string arrivalStation, DateTime departureDate)
    {
        int departureStationId = _context.TrainStations.FirstOrDefault(ts => ts.StationName == departureStation)?.Id ?? -1;
        int arrivalStationId = _context.TrainStations.FirstOrDefault(ts => ts.StationName == arrivalStation)?.Id ?? -1;

        if (departureStationId == -1 || arrivalStationId == -1)
        {
            return Enumerable.Empty<AppropriateTrainLineDto>();
        }

        var departureMovements = await _context.TrainMovements
            .Include(tm => tm.TrainLine)
            .ThenInclude(tl => tl.Trains)
            .ThenInclude(t => t.Wagons)
            .ThenInclude(w => w.TrainSeats)
            .Where(tm => tm.DepartureTime.HasValue &&
                         tm.DepartureTime.Value.Date == departureDate.Date &&
                         tm.TrainStationId == departureStationId &&
                         tm.TrainLine.Trains.Any(t => t.IsAvailable))
            .ToListAsync();

        var arrivalMovements = await _context.TrainMovements
            .Include(tm => tm.TrainLine)
            .ThenInclude(tl => tl.Trains)
            .ThenInclude(t => t.Wagons)
            .ThenInclude(w => w.TrainSeats)
            .Where(tm => tm.ArrivalTime.HasValue &&
                         tm.ArrivalTime.Value.Date == departureDate.Date &&
                         tm.TrainStationId == arrivalStationId)
            .ToListAsync();

        var appropriateLines = from departureMovement in departureMovements
                               join arrivalMovement in arrivalMovements
                               on departureMovement.TrainLineId equals arrivalMovement.TrainLineId
                               where departureMovement.DepartureTime < arrivalMovement.ArrivalTime
                               select new AppropriateTrainLineDto
                               {
                                   
                                   
                                   DepartureStation = departureStation,
                                   ArrivalStation = arrivalStation,
                                   DepartureTime = new TimeOnly(departureMovement.DepartureTime.Value.Hour, departureMovement.DepartureTime.Value.Minute),
                                   ArrivalTime = new TimeOnly(arrivalMovement.ArrivalTime.Value.Hour, arrivalMovement.ArrivalTime.Value.Minute),
                                   DepartureDate = departureMovement.DepartureTime.Value.Date,
                                   ArrivalDate = arrivalMovement.ArrivalTime.Value.Date,
                                   AvailablePlaces = departureMovement.TrainLine.Trains.SelectMany<Train, TrainSeat>(t => t.Wagons.SelectMany<Wagon, TrainSeat>(w => w.TrainSeats)).Count(s => s.StateType == StateType.empty),
                                   TotalPlaces = departureMovement.TrainLine.Trains.SelectMany<Train, TrainSeat>(t => t.Wagons.SelectMany<Wagon, TrainSeat>(w => w.TrainSeats)).Count(),
                                   Duration = GetDurationAsTimeOnly(departureMovement.DepartureTime.Value, arrivalMovement.ArrivalTime.Value),
                                   TrainLineName = departureMovement.TrainLine.LineName,
                                   TrainLineDescription = departureMovement.TrainLine.Description,
                                   TrainId = departureMovement.TrainLine.Trains.FirstOrDefault()?.Id ?? -1,
                                   TrainNumber = departureMovement.TrainLine.Trains.FirstOrDefault()?.TrainNumber ?? string.Empty,
                                   TrainType = departureMovement.TrainLine.Trains.FirstOrDefault()?.TrainType ?? default,

                                   WagonTypes = departureMovement.TrainLine.Trains.SelectMany(t => t.Wagons).Select(w => w.WagonType).Distinct().ToList(),
                                   Wagons = departureMovement.TrainLine.Trains
                                            .SelectMany(t => t.Wagons)
                                            .Select(w => new WagonDto
                                            {
                                                Number = w.Number,
                                                WagonType = w.WagonType,
                                                AvailableSeats = w.TrainSeats.Count(s => s.StateType == StateType.empty)
                                            }).ToList(),

                                   FirstPrices = CalculateFirstPrices(departureMovement.DistanceFromStart, arrivalMovement.DistanceFromStart)

                               };

        return appropriateLines.ToList();
    }

    private List<decimal> CalculateFirstPrices(int departureDistance, int arrivalDistance)
    {
        var distance = arrivalDistance - departureDistance;
        var prices = new List<decimal>
    {
        (decimal)(distance * 10 * 0.05), // PlackartEkonom
        (decimal)(distance * 10 * 0.2),  // SittingFirstClass
        (decimal)(distance * 10 * 0.1)   // SittingSecondClass
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

    public async Task<TrainLineDto> GetTrainDetailsByTrainNumberAsync(string trainLineName, int trainId, WagonType wagonType)
    {
        var trainLine = await _context.TrainLines
            .Where(tl => tl.LineName == trainLineName)
            .Select(tl => new TrainLineDto
            {
                LineName = tl.LineName,
                Description = tl.Description,
                Trains = tl.Trains
                    .Where(t => t.IsAvailable && t.Id == trainId)
                    .Select(t => new TrainDto
                    {
                        TrainId = t.Id,
                        TrainType = t.TrainType,
                        Wagons = t.Wagons
                            .Where(w => w.WagonType == wagonType && w.TrainSeats.Any(s => s.StateType == StateType.empty))
                            .Select(w => new WagonDto
                            {
                                Number = w.Number,
                                WagonId = w.Id,
                                WagonType = w.WagonType,
                                AvailableSeats = w.TrainSeats.Count(s => s.StateType == StateType.empty),
                                Seats = w.TrainSeats.Select(s => new TrainSeatDto
                                {
                                    SeatId = s.Id,
                                    Number = s.Number,
                                    StateType = s.StateType
                                }).ToList()
                            }).ToList()
                    }).ToList()
            })
            .FirstOrDefaultAsync();

        return trainLine ?? throw new Exception("Train line not found.");
    }

    public async Task ReserveSeats(SeatReservationRequestDto request)
    {
       
        var seats = await _context.TrainSeats
            .Include(s => s.Wagon)
            .ThenInclude(w => w.Train)
            .Where(s => s.Wagon.Train.Id == request.TrainId &&
                        s.Wagon.Id == request.WagonId &&
                        request.SeatNumbers.Contains(s.Number) &&
                        s.StateType == StateType.empty)
            .ToListAsync();

        foreach (var seat in seats)
        {
            seat.StateType = StateType.bought;
        }
        await _context.SaveChangesAsync();
    }


    public async Task BuyTrainTicketFail(PaymentTrainResponseFailDto paymentResponseFailDto)
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

        var seats = await _context.TrainSeats
            .Include(s => s.Wagon)
            .ThenInclude(w => w.Train)
            .Where(s => s.Wagon.Train.Id == paymentResponseFailDto.TrainId &&
                        s.Wagon.Id == paymentResponseFailDto.WagonId &&
                        paymentResponseFailDto.Seats.Contains(s.Number))
            .ToListAsync();

        foreach (var seat in seats)
        {
            seat.StateType = StateType.empty;
        }

        await _context.SaveChangesAsync();
    }


    public async Task BuyTrainTicketSuccess(PaymentTrainResponseSuccessDto paymentTrainResponseSuccessDto)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(o => o.OrderId == paymentTrainResponseSuccessDto.OrderId);

        if (order != null)
        {
            throw new Exception($"Order with OrderId {paymentTrainResponseSuccessDto.OrderId} already exists.");
        }
        else
        {
            order = new Order
            {
                OrderId = paymentTrainResponseSuccessDto.OrderId,
                OrderState = paymentTrainResponseSuccessDto.OrderStatus
            };
            await _context.Orders.AddAsync(order);
        }

        var trainTickets = new List<TrainTicket>();
        var purchaseHistories = new List<TrainPurchaseHistory>();
        var now = DateTime.UtcNow;

        foreach (var ticketDto in paymentTrainResponseSuccessDto.TrainTicketDtos)
        {
            var seat = await _context.TrainSeats
                .Include(s => s.Wagon)
                .ThenInclude(w => w.Train)
                .FirstOrDefaultAsync(s => s.Wagon.Train.Id == paymentTrainResponseSuccessDto.TrainId &&
                                          s.Wagon.Id == paymentTrainResponseSuccessDto.WagonId &&
                                          s.Number == ticketDto.SeatNumber);

            if (seat == null)
            {
                throw new Exception($"Seat number {ticketDto.SeatNumber} not found.");
            }

            seat.StateType = StateType.bought;

            var trainTicket = new TrainTicket
            {
                Email = ticketDto.Email,
                FirstName = ticketDto.FirstName,
                LastName = ticketDto.LastName,
                Price = ticketDto.Price,
                DateOfPurchase = now,
                TicketType = ticketDto.TicketType,
                SeatNumber = ticketDto.SeatNumber,
                WagonNumber = paymentTrainResponseSuccessDto.WagonId,
                TrainNumber = paymentTrainResponseSuccessDto.TrainId.ToString(), 
                TrainLineName = paymentTrainResponseSuccessDto.TrainLineName,
                TimeOfDeparture = paymentTrainResponseSuccessDto.TimeOfDeparture,
                TimeOfArrival = paymentTrainResponseSuccessDto.TimeOfArrival,
                StationOfDeparture = paymentTrainResponseSuccessDto.StationOfDeparture,
                StationOfArrival = paymentTrainResponseSuccessDto.StationOfArrival
            };

            await _context.TrainTickets.AddAsync(trainTicket);
            trainTickets.Add(trainTicket);

            if (!string.IsNullOrEmpty(ticketDto.UserId))
            {
                var purchaseHistory = new TrainPurchaseHistory
                {
                    OrderId = order.Id,
                    UserId = ticketDto.UserId,
                    TrainTicket = trainTicket,
                    Price = trainTicket.Price,
                    PurchaseDate = now
                };

                purchaseHistories.Add(purchaseHistory);
                await _context.TrainPurchaseHistory.AddAsync(purchaseHistory);
            }

            SendTicketPdfByEmail(trainTicket); 
        }

        await _context.SaveChangesAsync();
    }

    private void SendTicketPdfByEmail(TrainTicket trainTicket)
    {
        
        var pdfDocument = new PdfDocument();
        var page = pdfDocument.AddPage();
        var graphics = XGraphics.FromPdfPage(page);
        var font = new XFont("Verdana", 12);

        graphics.DrawString($"Train Ticket", font, XBrushes.Black,
        new XRect(0, 0, page.Width, page.Height),
        XStringFormats.TopCenter);

        graphics.DrawString($"Name: {trainTicket.FirstName} {trainTicket.LastName}", font, XBrushes.Black,
            new XRect(20, 40, page.Width, page.Height),
        XStringFormats.TopLeft);

        graphics.DrawString($"Email: {trainTicket.Email}", font, XBrushes.Black,
            new XRect(20, 60, page.Width, page.Height),
        XStringFormats.TopLeft);

        graphics.DrawString($"Train Number: {trainTicket.TrainNumber}", font, XBrushes.Black,
            new XRect(20, 80, page.Width, page.Height),
        XStringFormats.TopLeft);

        graphics.DrawString($"Departure: {trainTicket.StationOfDeparture} at {trainTicket.TimeOfDeparture}", font, XBrushes.Black,
            new XRect(20, 100, page.Width, page.Height),
        XStringFormats.TopLeft);

        graphics.DrawString($"Arrival: {trainTicket.StationOfArrival} at {trainTicket.TimeOfArrival}", font, XBrushes.Black,
            new XRect(20, 120, page.Width, page.Height),
            XStringFormats.TopLeft);

        // Save PDF to memory stream
        using (var stream = new MemoryStream())
        {
            pdfDocument.Save(stream, false);

            // Send email
            var client = new SmtpClient("smtp.example.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("", ""),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("noreply@globaltickethub.com"),
                Subject = "Your Train Ticket",
                Body = "Please find your train ticket attached.",
                IsBodyHtml = true,
            };
            mailMessage.To.Add(trainTicket.Email);
            mailMessage.Attachments.Add(new Attachment(new MemoryStream(stream.ToArray()), "TrainTicket.pdf"));

            client.Send(mailMessage);
        }
    }


}

