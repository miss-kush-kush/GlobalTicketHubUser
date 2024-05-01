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

namespace Domain.Entities.TrainEntities
{
    public class TrainTicket
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        public virtual AppUser User { get; set; }

        public int TrainLineId { get; set; }
        public virtual TrainLine TrainLine { get; set; }

        public int TrainOperationPlanId { get; set; }
        public virtual TrainOperationPlan TrainOperationPlan { get; set; }

        public int TrainStationId { get; set; }
        public virtual TrainStation TrainStation { get; set; }

        public TicketType TicketType { get; set; }

    }
}
