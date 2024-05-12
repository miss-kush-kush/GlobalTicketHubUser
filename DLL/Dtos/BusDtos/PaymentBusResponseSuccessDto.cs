using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.BusDtos
{
    public class PaymentBusResponseSuccessDto
    {
        public int BusId { get; set; }
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
        public List<BusTicketDto> BusTicketDtos { get; set; }
        public string BusLineName { get; set; }
        public DateTime TimeOfDeparture { get; set; }
        public DateTime TimeOfArrival { get; set; }
        public string StationOfDeparture { get; set; }
        public string StationOfArrival { get; set; }
    }
}
