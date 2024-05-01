using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.AuthDtos
{
    public class RoleserviceResponseDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public int TotalUsers { get; set; }
    }
}
