using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.TrainDtos
{
    public class TrainOperationPlanDto
    {
        public int TrainId { get; set; }
        public List<TrainStopDto> TrainStops { get; set; }
    }
}
