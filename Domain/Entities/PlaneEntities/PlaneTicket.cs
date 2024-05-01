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

namespace Domain.Entities.PlaneEntities
{
    public class PlaneTicket
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        public virtual AppUser User { get; set; }

        public int PlaneId { get; set; }
        public virtual Plane Plane { get; set; }

        public int PlaneOperationPlanId { get; set; }
        public virtual PlaneOperationPlan PlaneOperationPlan { get; set; }

        public TicketType TicketType { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string StudentCardNumber { get; set; }
    }
}
