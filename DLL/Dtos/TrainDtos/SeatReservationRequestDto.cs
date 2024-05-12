using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.TrainDtos
{
    public class SeatReservationRequestDto
    {
        public int TrainId { get; set; }
        public int WagonId { get; set; }
        public List<int> SeatNumbers { get; set; }
        public int BusId { get; set; }
    }
}
