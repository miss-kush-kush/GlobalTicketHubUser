using DLL.Dtos.AuthDtos;
using DLL.Dtos.UserDtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
        Task<UserDetailDto> GetUserDetailsAsync(string UserId);
        Task<List<UserDetailDto>> GetAllUserDetailsAsync();
        Task<AuthResponseDto> ChangePasswordAsync(ChangePasswordDto changePasswordDto);
        Task<AuthResponseDto> ResetPasswordAsync(ResetPasswordDto resetPasswordDto);
        Task<AuthResponseDto> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto);
        Task<AuthResponseDto> LogoutAsync(string userId);
    }
}
