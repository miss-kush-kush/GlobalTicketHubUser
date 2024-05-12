using Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.TrainDtos
{
    public class WagonDto
    {
        public int Number { get; set; }
        public WagonType WagonType { get; set; }
        public List<TrainSeatDto> Seats { get; set; }
        public int AvailableSeats { get; set; }
        public int WagonId { get; set; }
    }
}
