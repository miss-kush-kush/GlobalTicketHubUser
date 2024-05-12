using DLL.Dtos.TrainDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.PaymentDtos
{
    public class PaymentTrainResponseSuccessDto
    {
        public string OrderStatus { get; set; }
        public int OrderId { get; set; }
        public string TrainLineName { get; set; }
        public int TrainId{ get; set; }
        public int WagonId { get; set; }

        public DateTime TimeOfDeparture { get; set; }
        public DateTime TimeOfArrival { get; set; }
        public string StationOfDeparture { get; set; }
        public string StationOfArrival { get; set; }

        public List<TrainTicketDto> TrainTicketDtos { get; set; }

    }
}
