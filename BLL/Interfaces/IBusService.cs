using DLL.Dtos.BusDtos;
using DLL.Dtos.TrainDtos;
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
        Task<IEnumerable<AppropriateBusLineDto>> FindAppropriateLinesAsync(string departureStation, string arrivalStation, DateTime departureDate);
        Task<BusLineDto> GetBusDetailsByBusNumberAsync(string busLineName, int busId);
        Task ReserveSeats(SeatReservationRequestDto request);
        Task BuyBusTicketFail(PaymentBusResponseFailDto paymentResponseFailDto);
        Task BuyBusTicketSuccess(PaymentBusResponseSuccessDto paymentBusResponseSuccessDto);

    }
}
