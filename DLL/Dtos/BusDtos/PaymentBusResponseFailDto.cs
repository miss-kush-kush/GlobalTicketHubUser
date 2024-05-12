using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.BusDtos
{
    public class PaymentBusResponseFailDto
    {
        public List<int> Seats { get; set; }
        public int BusId { get; set; }
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
    }
}
