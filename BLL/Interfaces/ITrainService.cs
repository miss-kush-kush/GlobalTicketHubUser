using System.Collections.Generic;
using System.Threading.Tasks;
using DLL.Dtos.PaymentDtos;
using DLL.Dtos.TrainDtos;
using DLL.Dtos.UserDtos;
using Domain.Types;

public interface ITrainService
{
    Task<TrainLineDto> GetTrainDetailsByTrainNumberAsync(string trainLineName, int trainId, WagonType wagonType);
    
    Task<IEnumerable<AppropriateTrainLineDto>> FindAppropriateLinesAsync(
        string departureStation,
        string arrivalStation,
        DateTime departureDate
    );

    Task ReserveSeats(SeatReservationRequestDto request);
    Task BuyTrainTicketFail(PaymentTrainResponseFailDto paymentResponseFailDto);
    Task BuyTrainTicketSuccess(PaymentTrainResponseSuccessDto paymentTrainResponseSuccessDto);
}
