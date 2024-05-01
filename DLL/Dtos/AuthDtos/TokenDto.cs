using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.AuthDtos
{
    public class TokenDto
    {
        public string RefreshToken { get; set; } = null!;
        public string Token { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
