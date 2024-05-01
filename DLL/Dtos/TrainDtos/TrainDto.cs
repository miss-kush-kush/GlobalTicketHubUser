using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.TrainDtos
{
    public class TrainDto
    {
        public int Id { get; set; } // For updates and references
        public string TrainNumber { get; set; }
        public int TrainLineId { get; set; } // To link the train to its train line
        public List<WagonDto> Wagons { get; set; } = new List<WagonDto>();

    }
}
