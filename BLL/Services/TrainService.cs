using DLL.DbContext;
using Domain.Entities.LocationEntities;
using Domain.Entities.TrainEntities;
using BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using DLL.Dtos.TrainDtos;
using System.Diagnostics;
using System.Numerics;
using System.Security.Policy;
using static System.Collections.Specialized.BitVector32;
using Microsoft.Extensions.Hosting;
using Domain.Entities.UserEntities;
using Domain.Types;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class TrainService : ITrainService
{
    private readonly AppDbContext _context;

    public TrainService(AppDbContext context)
    {
        _context = context;
    }


    public Task AddTrainSchedulesAsync(List<TrainOperationPlanDto> trainOperationPlanDtos)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TrainDto>> GetTrainsByTrainLineAsync(int trainLineId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<WagonDto>> GetWagonsByTrainAsync(int trainId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TrainSeatDto>> GetSeatsByWagonAsync(int wagonId)
    {
        throw new NotImplementedException();
    }

    public Task AddTrainStationsAsync(List<TrainStationDto> trainStationDtos)
    {
        throw new NotImplementedException();
    }

    public Task AddTrainLinesAsync(List<TrainLineDto> trainLineDtos)
    {
        throw new NotImplementedException();
    }

    public Task AddTrainsAsync(List<TrainDto> trainDtos)
    {
        throw new NotImplementedException();
    }


    public async Task<IEnumerable<AppropriateTicketDto>> FindAppropriateTicketsAsync(
        string departureStation,
        string arrivalStation,
        DateTime departureDate)
    {
        // Step 1: Find TrainStations for the given departure and arrival stations
        var departureTrainStation = await _context.TrainStations
            .FirstOrDefaultAsync(station =>
                station.StationName.Equals(departureStation, StringComparison.OrdinalIgnoreCase));

        var arrivalTrainStation = await _context.TrainStations
            .FirstOrDefaultAsync(station =>
                station.StationName.Equals(arrivalStation, StringComparison.OrdinalIgnoreCase));

        if (departureTrainStation == null || arrivalTrainStation == null)
        {
            throw new InvalidOperationException("Invalid departure or arrival station.");
        }

        // Step 2: Find TrainStationSchedules for the specified departure date
        var trainStationSchedule = await _context.TrainStationSchedules
            .FirstOrDefaultAsync(schedule =>
                schedule.TrainStationId == departureTrainStation.Id &&
                schedule.ScheduleDate.Date == departureDate.Date);

        if (trainStationSchedule == null)
        {
            throw new InvalidOperationException("No train schedule found for the specified date.");
        }

        // Step 3: Find TrainOperationPlans for this schedule and get their TrainStops
        var trainOperationPlans = await _context.TrainOperationPlans
            .Include(plan => plan.TrainLine) // Include TrainLine
            .Where(plan => plan.TrainStops
                .Any(stop =>
                    stop.TrainStationId == departureTrainStation.Id &&
                    stop.DepartureTime.HasValue && // Ensure DepartureTime is not null
                    stop.DepartureTime.Value.Date == departureDate.Date)) // Access Date after confirming non-null
            .ToListAsync();

        if (!trainOperationPlans.Any())
        {
            throw new InvalidOperationException("No train operation plans found for the specified date.");
        }

        // Step 4: Retrieve TrainLines and associated Trains, Wagons, and TrainSeats
        var trainLine = await _context.TrainLines
            .FirstOrDefaultAsync(line =>
                trainOperationPlans.Any(plan => plan.TrainLineId == line.Id));

        if (trainLine == null)
        {
            throw new InvalidOperationException("No matching train line found.");
        }

        var trains = await _context.Trains
            .Where(train => train.TrainLineId == trainLine.Id)
            .Include(train => train.Wagons) // Include related Wagons
            .ThenInclude(wagon => wagon.TrainSeats) // Include related TrainSeats
            .ToListAsync();

        var appropriateTickets = new List<AppropriateTicketDto>();

        // Step 5: For each Train and Wagon, calculate TotalPlaces and AvailablePlaces
        foreach (var train in trains)
        {
            int totalPlaces = train.Wagons.Sum(wagon => wagon.TrainSeats.Count());
            int availablePlaces = train.Wagons.Sum(wagon =>
                wagon.TrainSeats.Count(seat => seat.StateType == StateType.empty));

            // Get the first TrainOperationPlan
            var firstPlan = trainOperationPlans.FirstOrDefault();

            if (firstPlan == null)
            {
                throw new InvalidOperationException("No valid train operation plan found.");
            }

            // Get the TrainStops from the first operation plan
            var firstStop = firstPlan.TrainStops.FirstOrDefault();
            var lastStop = firstPlan.TrainStops.LastOrDefault();

            if (firstStop == null || lastStop == null)
            {
                throw new InvalidOperationException("Invalid train stops for the specified plan.");
            }

            var ticketDto = new AppropriateTicketDto
            {
                DepartureStation = departureTrainStation.StationName,
                ArrivalStation = arrivalTrainStation.StationName,
                DepartureTime = firstStop.DepartureTime,
                ArrivalTime = lastStop.ArrivalTime,
                DepartureDate = departureDate,
                ArrivalDate = lastStop.ArrivalTime?.Date,
                TrainType = train.TrainType,
                TrainLineName = trainLine.LineName,
                TrainLineDescription = trainLine.Description,
                TotalPlaces = totalPlaces,
                AvailablePlaces = availablePlaces,
                Duration = (float)((lastStop.ArrivalTime - firstStop.DepartureTime)?.TotalHours ?? 0)
            };

            appropriateTickets.Add(ticketDto);
        }

        // Step 6: Return the list of AppropriateTicketDto
        return appropriateTickets;
    }




}
