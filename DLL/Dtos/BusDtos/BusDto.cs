using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.BusDtos
{
    public class BusDto
    {
        public int Id { get; set; } // For updates and references
        public string BusNumber { get; set; }
        public int BusLineId { get; set; } // To link the Bus to its Bus line
        public List<BusSeatDto> BusSeats { get; set; } = new List<BusSeatDto>();
    }
}
