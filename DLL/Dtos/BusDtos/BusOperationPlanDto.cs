using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.BusDtos
{
    public class BusOperationPlanDto
    {
        public int BusId { get; set; }
        public List<BusStopDto> BusStops { get; set; }
    }
}
