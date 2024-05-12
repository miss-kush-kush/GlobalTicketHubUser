using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.PaymentDtos
{
    public class PaymentTrainResponseFailDto
    {
        public string OrderStatus {  get; set; }
        public int OrderId {  get; set; } 
        public int TrainId { get; set; }
        public int WagonId { get; set; }
        public List<int> Seats { get; set; }
    }
}
