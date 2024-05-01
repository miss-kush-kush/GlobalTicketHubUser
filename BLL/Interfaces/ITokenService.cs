using DLL.Dtos.AuthDtos;
using Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITokenService
    {
        Task<AuthResponseDto> TokenAsync(TokenDto tokenDto);
        string GenerateRereshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
        string GenerateToken(AppUser user);
    }
}
