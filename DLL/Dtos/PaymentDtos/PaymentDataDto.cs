using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.PaymentDtos
{
    public class PaymentDataDto
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int Order_id { get; set; }
        public string Currency = "UAH";
        public string Action = "pay";
        public int Version = 3;
        public static string publicKey = "sandbox_i11794916005";
    }
}
