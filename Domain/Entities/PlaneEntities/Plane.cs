using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.PlaneEntities
{
    public class Plane
    {
        [Key]
        public int Id { get; set; }
        public string PlaneNumber { get; set; } 

        public int PlaneLineId { get; set; }
        public virtual PlaneLine PlaneLine { get; set; }

        public virtual ICollection<PlaneSeat> PlaneSeats { get; set; }
    }
}
