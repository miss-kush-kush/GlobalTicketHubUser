using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.TrainDtos
{
    public class WagonDto
    {
        public int Id { get; set; } // For updates and references
        public int Number { get; set; }
        public List<TrainSeatDto> TrainSeats { get; set; } = new List<TrainSeatDto>();
    }
}
