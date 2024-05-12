using Domain.Entities.TrainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.BusEntities;
using Domain.Entities.UserEntities;

namespace Domain.BusEntities
{
    public class BusPurchaseHistory
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public string UserId { get; set; }
        public virtual AppUser User { get; set; }

        public int BusTicketId { get; set; }
        public virtual BusTicket BusTicket { get; set; }

        public decimal Price { get; set; }

        public DateTime PurchaseDate { get; set; }
    }
}
