using DLL.DbContext;
using Domain.Entities.LocationEntities;
using Domain.Entities.BusEntities;
using BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using DLL.Dtos.BusDtos;
using System.Diagnostics;
using System.Numerics;
using System.Security.Policy;
using static System.Collections.Specialized.BitVector32;
using Microsoft.Extensions.Hosting;
using Domain.Types;

public class BusService : IBusService
{
    private readonly AppDbContext _context;

    public BusService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddBusStationsAsync(List<BusStationDto> BusStationDtos) // Add multiple Bus stations
    {
        var BusStations = BusStationDtos.Select(dto => new BusStation
        {
            StationName = dto.StationName,
            LocationId = dto.LocationId
        }).ToList();

        _context.BusStations.AddRange(BusStations); // Add all at once
        await _context.SaveChangesAsync();
    }

    public async Task AddBusLinesAsync(List<BusLineDto> BusLineDtos) // Add multiple Bus lines
    {
        var BusLines = BusLineDtos.Select(dto => new BusLine
        {
            LineName = dto.LineName,
            Description = dto.Description
        }).ToList();

        _context.BusLines.AddRange(BusLines); // Add all at once
        await _context.SaveChangesAsync();
    }

    //public async Task AddBusesAsync(List<BusDto> BusDtos) // Add multiple Buss
    //{
    //    var Buss = BusDtos.Select(dto => new Bus
    //    {
    //        BusNumber = dto.BusNumber,
    //        BusLineId = dto.BusLineId,
    //        Seats = Enumerable.Range(1, 40).Select(seatNumber => new BusSeat
    //            {
    //                Number = seatNumber,
    //                IsAvailable = true
    //            }).ToList()
    //        }).ToList(); // Create a list of Buss

    //    _context.Buses.AddRange(Buss); // Add all at once
    //    await _context.SaveChangesAsync(); // Save changes to the database
    //}

    //public async Task AddBusSchedulesAsync(List<BusOperationPlanDto> BusOperationPlanDtos) // Add multiple Bus schedules
    //{
    //    var BusSchedules = BusOperationPlanDtos.Select(dto => new BusOperationPlan
    //    {
    //        BusLineId = dto.BusId,
    //        BusStops = dto.BusStops.Select(ts => new BusStop
    //        {
    //            StationId = ts.StationId,
    //            ArrivalTime = ts.ArrivalTime,
    //            DepartureTime = ts.DepartureTime,
    //            DistanceFromStart = ts.DistanceFromStart
    //        }).ToList()
    //    }).ToList();

    //    _context.BusOperationPlans.AddRange(BusSchedules); // Add all at once
    //    await _context.SaveChangesAsync();
    //}

    //public async Task<IEnumerable<BusDto>> GetBusesByBusLineAsync(int BusLineId)
    //{
    //    return await _context.Buses
    //        .Where(t => t.BusLineId == BusLineId)
    //        .Select(t => new BusDto
    //        {
    //            Id = t.Id,
    //            BusNumber = t.BusNumber,
    //            BusLineId = t.BusLineId,
    //            Seats = t.Seats.Select(s => new BusSeatDto
    //            {
    //                Id = s.Id,
    //                Number = s.Number,
    //                IsAvailable = s.IsAvailable
    //            }).ToList()
    //        }).ToListAsync();
    //}


    //public async Task<IEnumerable<BusTicketDto>> FindAppropriateTicketsAsync(string departureStation, string arrivalStation, DateTime departureDate, int? passengerCount = null, TicketType? ticketType = null)
    //{
    //    var matchingOperations = await _context.BusOperationPlans
    //        .Include(plan => plan.BusLine) // To get Bus line information
    //        .Include(plan => plan.BusStops) // To get the stop details
    //        .Where(plan =>
    //            plan.BusStops.Any(stop => stop.Station.StationName == departureStation) &&
    //            plan.BusStops.Any(stop => stop.Station.StationName == arrivalStation) &&
    //            plan.BusStops.First().DepartureTime.HasValue &&
    //            plan.BusStops.First().DepartureTime.Value.Date == departureDate.Date)
    //        .ToListAsync();

    //    var tickets = matchingOperations.Select(plan =>
    //    {
    //        var departureStop = plan.BusStops.First(stop => stop.Station.StationName == departureStation);
    //        var arrivalStop = plan.BusStops.First(stop => stop.Station.StationName == arrivalStation);

    //        var price = CalculatePrice(departureStation, arrivalStation, passengerCount, ticketType);

    //        return new BusTicketDto
    //        {
    //            Id = plan.Id, // Unique identifier for the ticket
    //            BusNumber = plan.BusLine.LineName, // Bus line identifier
    //            DepartureStation = departureStation,
    //            ArrivalStation = arrivalStation,
    //            DepartureTime = departureStop.DepartureTime,
    //            ArrivalTime = arrivalStop.ArrivalTime,
    //            Price = price, // Calculated price with optional discounts
    //            PassengerCount = passengerCount // Optional passenger count
    //        };
    //    });

    //    return tickets;
    //}

    //private decimal CalculatePrice(string departureStation, string arrivalStation, int? passengerCount, TicketType? ticketType)
    //{
    //    var BusStops = _context.BusOperationPlans
    //        .SelectMany(plan => plan.BusStops)
    //        .Where(
    //            ts => ts.Station.StationName == departureStation ||
    //                  ts.Station.StationName == arrivalStation
    //        )
    //        .OrderBy(ts => ts.Station.StationName == departureStation ? 0 : 1)
    //        .Select(ts => ts.DistanceFromStart) // Correct reference
    //        .ToArray();

    //    var distance = BusStops[1] - BusStops[0];
    //    var basePrice = distance * 0.5m;
    //    var adjustedPassengerCount = passengerCount ?? 1;

    //    // Apply discounts based on ticket type
    //    decimal discount = 0;
    //    if (ticketType.HasValue)
    //    {
    //        if (ticketType.Value == TicketType.Student)
    //        {
    //            discount = 0.5m; // 50% discount for students
    //        }
    //        else if (ticketType.Value == TicketType.Child)
    //        {
    //            discount = 0.1m; // 10% discount for children
    //        }
    //    }

    //    var totalPrice = basePrice * adjustedPassengerCount * (1 - discount);

    //    return totalPrice;
    //}

    public Task AddBusesAsync(List<BusDto> busDtos)
    {
        throw new NotImplementedException();
    }

    public Task AddBusSchedulesAsync(List<BusOperationPlanDto> busOperationPlanDtos)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BusDto>> GetBusesByBusLineAsync(int trainLineId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BusTicketDto>> FindAppropriateTicketsAsync(string departureStation, string arrivalStation, DateTime departureDate, int? passengerCount = null, TicketType? ticketType = null)
    {
        throw new NotImplementedException();
    }
}
