using Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.BusDtos
{
    public class BusSeatDto
    {
        public int Number { get; set; }
        public int SeatId { get; set; }
        public StateType StateType { get; set; }
        public int AvailableSeats { get; set; }
    }
}
