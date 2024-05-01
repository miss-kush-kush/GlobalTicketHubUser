using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.AuthDtos
{
    public class AuthResponseDto
    {
        public string? Token { get; set; } = string.Empty;
        public bool IsSucceed { get; set; }
        public string? Message { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
    }
}
