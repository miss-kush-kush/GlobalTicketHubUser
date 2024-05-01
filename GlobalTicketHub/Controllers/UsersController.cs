using DLL.Dtos.AuthDtos;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace GlobalTicketHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserAuthService _authService;
        private readonly ITokenService _tokenService;

        public UsersController(IUserAuthService authService, ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        
        // Route -> Register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registerResult = await _authService.RegisterAsync(registerDto);

            if (registerResult.IsSucceed)
                return Ok(registerResult);

            return BadRequest(registerResult);
        }


        // Route -> Login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loginResult = await _authService.LoginAsync(loginDto);

            if (loginResult.IsSucceed)
            {
                return Ok(loginResult);
            }

            return Unauthorized(loginResult);
        }

        //api/user/detail
        [HttpGet("detail")]
        public async Task<IActionResult> GetUserDetail()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userDetails = await _authService.GetUserDetailsAsync(currentUserId);
            if (userDetails == null)
            {
                return NotFound(new { Message = "User not found" });
            }
            return Ok(userDetails);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _authService.GetAllUserDetailsAsync();
            return Ok(users);
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenDto tokenDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tokenResult = await _tokenService.TokenAsync(tokenDto);

            if (tokenResult.IsSucceed)
                return Ok(tokenResult);

            return BadRequest(tokenResult);


        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            var changeResult = await _authService.ChangePasswordAsync(changePasswordDto);
            if (changeResult.IsSucceed)
                return Ok(changeResult);

            return BadRequest(changeResult);

        }


        [AllowAnonymous]
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var resetResult = await _authService.ResetPasswordAsync(resetPasswordDto);
            if (resetResult.IsSucceed)
                return Ok(resetResult);

            return BadRequest(resetResult);
        }


        [AllowAnonymous]
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            var forgotResult = await _authService.ForgotPasswordAsync(forgotPasswordDto);
            if (forgotResult.IsSucceed)
                return Ok(forgotResult);

            return BadRequest(forgotResult);
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var logoutResult = await _authService.LogoutAsync(userId);
            return Ok(logoutResult);
        }
    }
}
