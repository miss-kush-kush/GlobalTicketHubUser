using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DLL.Mapper;
using DLL.Dtos.FeedbackDtos;
using Domain.Entities.UserEntities;
using BLL.Interfaces;
using Microsoft.AspNetCore.SignalR;
using DLL.Dtos.TrainDtos;
//using DLL.Dtos.BusDtos;
using Domain.Types;
using DLL.Dtos.PaymentDtos;

namespace GlobalTicketHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IFeedbackService _feedbackRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITrainService _trainService;
        private readonly IPaymentService _paymentService;

        public HomeController(IFeedbackService feedbackRepo, UserManager<AppUser> userManager, ITrainService trainService, IPaymentService paymentService)
        {
            _feedbackRepo = feedbackRepo;
            _userManager = userManager;
            _trainService = trainService;
            _paymentService = paymentService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var feedbacks = await _feedbackRepo.GetAllAsync();
            var feedbackDto = feedbacks.Select(s => s.ToFeedbackDto());
            return Ok(feedbackDto);
        }


        [HttpPost("post-feedback")]
        [Authorize] 
        public async Task<IActionResult> PostFeedback([FromBody] FeedbackSubmissionDto feedbackDto)
        {
            // Retrieve the current user ID from the UserManager
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            // Map DTO to Feedback entity
            var feedback = new Feedback
            {
                UserId = user.Id,
                Comment = feedbackDto.Comment,
                Rating = feedbackDto.Rating,
                DatePosted = DateTime.UtcNow
            };

            // Save the feedback
            var savedFeedback = await _feedbackRepo.SaveFeedbackAsync(feedback);

            // Convert to DTO to return
            var feedbackToReturn = savedFeedback.ToFeedbackDto();

            // Return the saved feedback DTO
            return Ok(feedbackToReturn);
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
                var lines = await _trainService.FindAppropriateLinesAsync(departureStation, arrivalStation, departureDate);
                if (!lines.Any())
                    return NotFound("No appropriate lines found for the given criteria.");

                return Ok(lines);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("train-details")]
        public async Task<IActionResult> GetTrainDetails(
            [FromQuery] string trainLineName, 
            [FromQuery] int trainId,
            [FromQuery] WagonType wagonType)
        {
            try
            {
                var trainDetails = await _trainService.GetTrainDetailsByTrainNumberAsync(trainLineName, trainId, wagonType);
                if (trainDetails == null)
                {
                    return NotFound("Train line details not found.");
                }
                return Ok(trainDetails);
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
                await _trainService.ReserveSeats(reservationRequest);
                return Ok(new { message = "Seats reserved successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while reserving seats: {ex.Message}");
            }
        }


        [HttpPost("ticket-payment")]
        public async Task<IActionResult> TicketPayment([FromBody] BasicPaymentInfoDto basicPaymentInfoDto)
        {
            try
            {
                var result = await _paymentService.TicketPayment(basicPaymentInfoDto);
                if (result == null)
                {
                    return NotFound("Payment was not created.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while creating payment: {ex.Message}");
            }
        }

        [HttpPost("buy-train-ticket-failure")]
        public async Task<IActionResult> BuyTrainTicketFail([FromBody] PaymentTrainResponseFailDto paymentTrainResponseFailDto)
        {
            try
            {
                await _trainService.BuyTrainTicketFail(paymentTrainResponseFailDto);
                return Ok(new { message = "Seats are empty again" });
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while reserving seats: {ex.Message}");
            }
        }

        [HttpPost("buy-train-ticket-success")]
        public async Task<IActionResult> BuyTrainTicketSuccess([FromBody] PaymentTrainResponseSuccessDto paymentTrainResponseSuccessDto)
        {
            try
            {
                await _trainService.BuyTrainTicketSuccess(paymentTrainResponseSuccessDto);
                return Ok(new { message = "Tickets bought successfuly" });
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while reserving seats: {ex.Message}");
            }
        }

    }
}
