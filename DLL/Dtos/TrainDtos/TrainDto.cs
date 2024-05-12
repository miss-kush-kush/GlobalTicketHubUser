using Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.TrainDtos
{
    public class TrainDto
    {
        public int TrainId { get; set; }
        public TrainType TrainType { get; set; }
        public List<WagonDto> Wagons { get; set; }
    }
}
