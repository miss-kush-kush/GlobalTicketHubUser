using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.PlaneDtos
{
    public class PlaneDto
    {
        public int Id { get; set; } // For updates and references
        public string PlaneNumber { get; set; }
        public int PlaneLineId { get; set; } // To link the Plane to its Plane line
        public List<PlaneSeatDto> PlaneSeats { get; set; } = new List<PlaneSeatDto>();
    }
}
