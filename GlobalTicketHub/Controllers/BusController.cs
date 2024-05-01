using BLL.Interfaces;
using DLL.Dtos.FeedbackDtos;
using Domain.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GlobalTicketHub.Controllers
{
    public class BusController : Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class HomeController : ControllerBase
        {
            private readonly IBusService _busRepo;

            [HttpGet("find-appropriate-tickets")]
            public async Task<IActionResult> FindAppropriateTickets(
                [FromQuery] string departureStation,
                [FromQuery] string arrivalStation,
                [FromQuery] DateTime departureDate,
                [FromQuery] int? passengerCount = null,
                [FromQuery] TicketType? ticketType = null
            )
            {
                var tickets = await _busRepo.FindAppropriateTicketsAsync(departureStation, arrivalStation, departureDate, passengerCount, ticketType);

                return Ok(tickets);
            }
        }
    }
}
