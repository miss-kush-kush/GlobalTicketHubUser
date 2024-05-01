using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Domain.Entities.PlaneEntities
{
    public class PlaneOperationPlan
    {
        [Key]
        public int Id { get; set; }
        public int PlaneLineId { get; set; } 
        public virtual PlaneLine PlaneLine { get; set; } 
        public virtual ICollection<PlaneStop> PlaneStops { get; set; }
    }
}
