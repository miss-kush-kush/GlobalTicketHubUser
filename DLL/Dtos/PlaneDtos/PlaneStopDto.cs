using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.PlaneDtos
{
    public class PlaneStopDto
    {
        public int StationId { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public int DistanceFromStart { get; set; }
    }
}
