using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.UserEntities
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string OrderState { get; set; }
    }
}
