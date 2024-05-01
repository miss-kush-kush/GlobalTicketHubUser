using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.BusEntities;
using Domain.Entities.TrainEntities;
using Domain.Entities.PlaneEntities;

namespace Domain.Entities.UserEntities
{
    public class BookingHistory
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        public virtual AppUser User { get; set; }

        public int TrainTicketId { get; set; }
        public virtual TrainTicket TrainTicket { get; set; }

        public int BusTicketId { get; set; }
        public virtual BusTicket BusTicket { get; set; }

        public int PlaneTicketId { get; set; }
        public virtual PlaneTicket PlaneTicket { get; set; }

        public int Price { get; set; }

        public DateTime BookingDate { get; set; }
    }
}
