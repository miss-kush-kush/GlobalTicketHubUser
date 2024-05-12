using BLL.Interfaces;
using DLL.Dtos.BusDtos;
using DLL.Dtos.FeedbackDtos;
using DLL.Dtos.PaymentDtos;
using DLL.Dtos.TrainDtos;
using Domain.Entities.UserEntities;
using Domain.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GlobalTicketHub.Controllers
{
    public class BusController : Controller
    {
        private readonly IBusService _busService;
        private readonly IPaymentService _paymentService;

        public BusController(IBusService busService, IPaymentService paymentService)
        {
            _busService = busService;
            _paymentService = paymentService;
        }

        [HttpGet("find-appropriate-lines")]
        public async Task<IActionResult> FindAppropriateLines(
            [FromQuery] string departureStation,
            [FromQuery] string arrivalStation,
            [FromQuery] DateTime departureDate
        )
        {
            try
            {
                var lines = await _busService.FindAppropriateLinesAsync(departureStation, arrivalStation, departureDate);
                if (!lines.Any())
                    return NotFound("No appropriate lines found for the given criteria.");

                return Ok(lines);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("bus-details")]
        public async Task<IActionResult> GetBusDetails(
            [FromQuery] string busLineName,
            [FromQuery] int busId)
        {
            try
            {
                var busDetails = await _busService.GetBusDetailsByBusNumberAsync(busLineName, busId);
                if (busDetails == null)
                {
                    return NotFound("Bus line details not found.");
                }
                return Ok(busDetails);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("reserve-seats")]
        public async Task<IActionResult> ReserveSeats([FromBody] SeatReservationRequestDto reservationRequest)
        {
            try
            {
                await _busService.ReserveSeats(reservationRequest);
                return Ok(new { message = "Seats reserved successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while reserving seats: {ex.Message}");
            }
        }

        //[HttpPost("ticket-payment")]
        //public async Task<IActionResult> TicketPayment([FromBody] BasicPaymentInfoDto basicPaymentInfoDto)
        //{
        //    try
        //    {
        //        var result = await _paymentService.TicketPayment(basicPaymentInfoDto);
        //        if (result == null)
        //        {
        //            return NotFound("Payment was not created.");
        //        }
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"An error occurred while creating payment: {ex.Message}");
        //    }
        //}

        [HttpPost("buy-bus-ticket-failure")]
        public async Task<IActionResult> BuyBusTicketFail([FromBody] PaymentBusResponseFailDto paymentBusResponseFailDto)
        {
            try
            {
                await _busService.BuyBusTicketFail(paymentBusResponseFailDto);
                return Ok(new { message = "Seats are empty again" });
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while reserving seats: {ex.Message}");
            }
        }

        [HttpPost("buy-bus-ticket-success")]
        public async Task<IActionResult> BuyBusTicketSuccess([FromBody] PaymentBusResponseSuccessDto paymentBusResponseSuccessDto)
        {
            try
            {
                await _busService.BuyBusTicketSuccess(paymentBusResponseSuccessDto);
                return Ok(new { message = "Seats are empty again" });
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while reserving seats: {ex.Message}");
            }
        }
    }
}

