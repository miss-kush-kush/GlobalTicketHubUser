using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DLL.Mapper;
using DLL.Dtos.FeedbackDtos;
using Domain.Entities.UserEntities;
using BLL.Interfaces;
using Domain.Types;

namespace GlobalTicketHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IFeedbackService _feedbackRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITrainService _trainService;

        public HomeController(IFeedbackService feedbackRepo, UserManager<AppUser> userManager, ITrainService trainService)
        {
            _feedbackRepo = feedbackRepo;
            _userManager = userManager;
            _trainService = trainService;
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


        [HttpGet("find-appropriate-tickets")]
        public async Task<IActionResult> FindAppropriateTickets(
            [FromQuery] string departureStation,
            [FromQuery] string arrivalStation,
            [FromQuery] DateTime departureDate
        )
        {
            var tickets = await _trainService.FindAppropriateTicketsAsync(departureStation, arrivalStation, departureDate);

            return Ok(tickets);
        }

    }
}
