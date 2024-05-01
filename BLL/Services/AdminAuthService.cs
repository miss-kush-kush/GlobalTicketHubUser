using DLL.Dtos.AuthDtos;
using DLL.Dtos.UserDtos;
using BLL.Interfaces;
using BLL.OtherObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Net;
using Domain.Entities.UserEntities;

namespace BLL.Services
{
    public class AdminAuthService : IAdminAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        public AdminAuthService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }


        public async Task<AuthResponseDto> AdminLoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user is null)
                return new AuthResponseDto()
                {
                    IsSucceed = false,
                    Message = "User not found with this Email"
                };

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!isPasswordCorrect)
                return new AuthResponseDto()
                {
                    IsSucceed = false,
                    Message = "Invalid Password."
                };

            var token = _tokenService.GenerateToken(user);
            var refreshToken = _tokenService.GenerateRereshToken();
            int.TryParse(_configuration.GetSection("JWT").GetSection("RefreshTokenValidityIn").Value!, out int RefreshTokenValidityIn);
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(RefreshTokenValidityIn);
            await _userManager.UpdateAsync(user);


            return new AuthResponseDto()
            {
                IsSucceed = true,
                Message = "Login Success",
                Token = token,
                RefreshToken = refreshToken
            };
        }

        public async Task<AuthResponseDto> AdminRegisterAsync(RegisterDto registerDto)
        {
            if (string.IsNullOrEmpty(registerDto.Email) || string.IsNullOrEmpty(registerDto.Password))
            {
                return new AuthResponseDto { IsSucceed = false, Message = "Missing Email or Password." };
            }

            var userExists = await _userManager.FindByEmailAsync(registerDto.Email);
            if (userExists != null)
            {
                return new AuthResponseDto { IsSucceed = false, Message = "Admin already exists." };
            }


            AppUser newUser = new AppUser()
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerDto.Email
            };

            var createUserResult = await _userManager.CreateAsync(newUser, registerDto.Password);

            if (!createUserResult.Succeeded)
            {
                var errorString = "User Creation Failed Beacause: ";
                foreach (var error in createUserResult.Errors)
                {
                    errorString += " # " + error.Description;
                }
                return new AuthResponseDto()
                {
                    IsSucceed = false,
                    Message = errorString
                };
            }
            
            if (registerDto.Roles is null)
            {
                await _userManager.AddToRoleAsync(newUser, StaticUserRoles.ADMIN);
            }
            else
            {
                foreach (var role in registerDto.Roles)
                {
                    await _userManager.AddToRoleAsync(newUser, role);
                }
            }

            var token = _tokenService.GenerateToken(newUser);
            var refreshToken = _tokenService.GenerateRereshToken();
            int.TryParse(_configuration.GetSection("JWT").GetSection("RefreshTokenValidityIn").Value!, out int RefreshTokenValidityIn);
            newUser.RefreshToken = refreshToken;
            newUser.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(RefreshTokenValidityIn);
            await _userManager.UpdateAsync(newUser);

            return new AuthResponseDto()
            {
                IsSucceed = true,
                Message = "User Created Successfully",
                Token = token,
                RefreshToken = refreshToken
            };
        }

        public async Task<AuthResponseDto> SeedRolesAsync()
        {
            bool isAdminRoleExists = await _roleManager.RoleExistsAsync(StaticUserRoles.ADMIN);
            bool isUserRoleExists = await _roleManager.RoleExistsAsync(StaticUserRoles.USER);

            if (isAdminRoleExists && isUserRoleExists)
                return new AuthResponseDto()
                {
                    IsSucceed = true,
                    Message = "Roles Seeding is Already Done"
                };

            await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.USER));
            await _roleManager.CreateAsync(new IdentityRole(StaticUserRoles.ADMIN));

            return new AuthResponseDto()
            {
                IsSucceed = true,
                Message = "Role Seeding Done Successfully"
            };
        }

        public async Task<UserDetailDto> AdminGetUserDetailsAsync(string UserId)
        {
            var user = await _userManager.FindByIdAsync(UserId);
            if (user == null) return null;

            var Roles = await _userManager.GetRolesAsync(user);

            return new UserDetailDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Roles = Roles.ToArray(),
                PhoneNumber = user.PhoneNumber,
                TwoFactorEnabled = user.TwoFactorEnabled,
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                AccessFailedCount = user.AccessFailedCount
            };
        }

        public async Task<List<UserDetailDto>> AdminGetAllUserDetailsAsync()
        {
            var users = _userManager.Users;
            var userDetailsList = new List<UserDetailDto>();

            foreach (var user in users)
            {
                var Roles = await _userManager.GetRolesAsync(user);
                userDetailsList.Add(new UserDetailDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Roles = Roles.ToArray(),
                    PhoneNumber = user.PhoneNumber,
                    TwoFactorEnabled = user.TwoFactorEnabled,
                    EmailConfirmed = user.EmailConfirmed,
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                    AccessFailedCount = user.AccessFailedCount
                });
            }

            return userDetailsList;
        }

        public async Task<AuthResponseDto> AdminChangePasswordAsync(ChangePasswordDto changePasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(changePasswordDto.Email);
            if (user is null)
            {
                return new AuthResponseDto
                {
                    IsSucceed = false,
                    Message = "User does not exist with this email"
                };
            }

            var result = await _userManager.ChangePasswordAsync(user, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);

            if (result.Succeeded)
            {
                return new AuthResponseDto
                {
                    IsSucceed = true,
                    Message = "Password changed successfully"
                };
            }

            return new AuthResponseDto
            {
                IsSucceed = false,
                Message = result.Errors.FirstOrDefault()!.Description
            };
        }

        public async Task<AuthResponseDto> AdminResetPasswordAsync(ResetPasswordDto resetPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
            resetPasswordDto.Token = WebUtility.UrlDecode(resetPasswordDto.Token);

            if (user is null)
            {
                return new AuthResponseDto
                {
                    IsSucceed = false,
                    Message = "User does not exist with this email"
                };
            }

            var result = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.NewPassword);

            if (result.Succeeded)
            {
                return new AuthResponseDto
                {
                    IsSucceed = true,
                    Message = "Password reset successfully"
                };
            }

            return new AuthResponseDto
            {
                IsSucceed = false,
                Message = result.Errors.FirstOrDefault()?.Description
            };
        }

        public async Task<AuthResponseDto> AdminForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);

            if (user is null)
            {
                return new AuthResponseDto
                {
                    IsSucceed = false,
                    Message = "User does not exist with this email"
                };
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = $"http://localhost:4200/reset-password?email={user.Email}&token={WebUtility.UrlEncode(token)}";

            var client = new RestClient("https://send.api.mailtrap.io/api/send");

            var request = new RestRequest
            {
                Method = Method.Post,
                RequestFormat = DataFormat.Json
            };

            request.AddHeader("Authorization", "Bearer 62a57db5c125073400f28db0b418c6d0");
            request.AddJsonBody(new
            {
                from = new { email = "mailtrap@demomailtrap.com" },
                to = new[] { new { email = user.Email } },
                template_uuid = "b8bd784f-961a-4c6f-bdcd-fbddfc8ceabe",
                template_variables = new { user_email = user.Email, pass_reset_link = resetLink }
            });

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return new AuthResponseDto
                {
                    IsSucceed = true,
                    Message = "Email sent with password reset link. Please check your email."
                };
            }
            else
            {
                return new AuthResponseDto
                {
                    IsSucceed = false,
                    Message = response.Content!.ToString()
                };
            }

        }

        public async Task<AuthResponseDto> AdminLogoutAsync(string userId)
        {
            // Invalidate the session if using cookie-based sessions
            await _signInManager.SignOutAsync();

            // If using JWT refresh tokens, find the user and invalidate their refresh token
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.RefreshToken = null; // Invalidate the refresh token
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(-1); // Optionally, set the refresh token's expiry to the past
                await _userManager.UpdateAsync(user);
            }

            return new AuthResponseDto
            {
                IsSucceed = true,
                Message = "Logout successful."
            };
        }
    }
}

