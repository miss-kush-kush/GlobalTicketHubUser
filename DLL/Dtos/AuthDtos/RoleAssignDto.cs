using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.AuthDtos
{
    public class RoleAssignDto
    {
        public string UserId { get; set; } = null!;
        public string RoleId { get; set; } = null!;
    }
}
