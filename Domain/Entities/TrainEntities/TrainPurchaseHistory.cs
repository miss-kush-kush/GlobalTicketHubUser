using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.UserEntities;

namespace Domain.Entities.TrainEntities
{
    public class TrainPurchaseHistory
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public string UserId { get; set; }
        public virtual AppUser User { get; set; }

        public int TrainTicketId { get; set; }
        public virtual TrainTicket TrainTicket { get; set; }

        public decimal Price { get; set; }

        public DateTime PurchaseDate { get; set; }
    }
}
