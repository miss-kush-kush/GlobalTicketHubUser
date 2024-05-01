using DLL.Dtos.AuthDtos;
using DLL.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAdminAuthService
    {
        Task<AuthResponseDto> SeedRolesAsync();
        Task<AuthResponseDto> AdminRegisterAsync(RegisterDto registerDto);
        Task<AuthResponseDto> AdminLoginAsync(LoginDto loginDto);
        Task<UserDetailDto> AdminGetUserDetailsAsync(string UserId);
        Task<List<UserDetailDto>> AdminGetAllUserDetailsAsync();
        Task<AuthResponseDto> AdminChangePasswordAsync(ChangePasswordDto changePasswordDto);
        Task<AuthResponseDto> AdminResetPasswordAsync(ResetPasswordDto resetPasswordDto);
        Task<AuthResponseDto> AdminForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto);
        Task<AuthResponseDto> AdminLogoutAsync(string userId);
    }
}
