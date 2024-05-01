using Domain.Entities.TrainEntities;
using Domain.Entities.UserEntities;
using Domain.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.BusEntities
{
    public class BusTicket
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        public virtual AppUser User { get; set; }

        public int BusId { get; set; }
        public virtual Bus Bus { get; set; }

        public int BusOperationPlanId { get; set; }
        public virtual BusOperationPlan BusOperationPlan { get; set; }

        public TicketType TicketType { get; set; }

        public BusType BusType { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string StudentCardNumber { get; set; }
    }
}
