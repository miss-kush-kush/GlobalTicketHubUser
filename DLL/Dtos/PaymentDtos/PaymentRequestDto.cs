using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.PaymentDtos
{
    public class PaymentRequestDto
    {
        public string Data { get; set; }
        public string Signature { get; set; }
        public int Order_id { get; set; }
    }
}
