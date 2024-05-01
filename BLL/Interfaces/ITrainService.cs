using System.Collections.Generic;
using System.Threading.Tasks;
using DLL.Dtos.TrainDtos;
using Domain.Types;

public interface ITrainService
{
    // Methods for adding countries, locations, train stations, train lines, trains, and schedules
    Task AddTrainStationsAsync(List<TrainStationDto> trainStationDtos);
    Task AddTrainLinesAsync(List<TrainLineDto> trainLineDtos);
    Task AddTrainsAsync(List<TrainDto> trainDtos);
    Task AddTrainSchedulesAsync(List<TrainOperationPlanDto> trainOperationPlanDtos);

    // Existing methods for retrieving train-related information
    Task<IEnumerable<TrainDto>> GetTrainsByTrainLineAsync(int trainLineId);
    Task<IEnumerable<WagonDto>> GetWagonsByTrainAsync(int trainId);
    Task<IEnumerable<TrainSeatDto>> GetSeatsByWagonAsync(int wagonId);

    // New method for finding appropriate train tickets
    Task<IEnumerable<AppropriateTicketDto>> FindAppropriateTicketsAsync(
        string departureStation,
        string arrivalStation,
        DateTime departureDate
    );
}
