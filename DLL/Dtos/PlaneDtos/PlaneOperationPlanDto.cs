using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.PlaneDtos
{
    public class PlaneOperationPlanDto
    {
        public int PlaneId { get; set; }
        public List<PlaneStopDto> PlaneStops { get; set; }
    }
}
