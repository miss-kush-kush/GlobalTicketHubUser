using DLL.Dtos.BusDtos;
using Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBusService
    {
        Task AddBusStationsAsync(List<BusStationDto> busStationDtos);
        Task AddBusLinesAsync(List<BusLineDto> busLineDtos);
        Task AddBusesAsync(List<BusDto> busDtos);
        Task AddBusSchedulesAsync(List<BusOperationPlanDto> busOperationPlanDtos);

        // Existing methods for retrieving train-related information
        Task<IEnumerable<BusDto>> GetBusesByBusLineAsync(int trainLineId);
        // New method for finding appropriate train tickets
        Task<IEnumerable<BusTicketDto>> FindAppropriateTicketsAsync(
            string departureStation,
            string arrivalStation,
            DateTime departureDate,
            int? passengerCount = null, // Optional
            TicketType? ticketType = null // Optional
        );
    }
}
