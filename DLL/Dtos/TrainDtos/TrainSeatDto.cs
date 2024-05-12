using Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.TrainDtos
{
    public class TrainSeatDto
    {
        public int Number { get; set; }
        public List<SeatType> SeatType { get; set; }
        public StateType StateType { get; set; }
        public int SeatId { get; set; }
    }
}
