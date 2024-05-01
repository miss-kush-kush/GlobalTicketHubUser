using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.PlaneEntities
{
    public class PlaneStop
    {
        [Key]
        public int Id { get; set; }
        public int PlaneOperationPlanId { get; set; }
        public virtual PlaneOperationPlan PlaneOperationPlan { get; set; }

        public int PlaneStationId { get; set; }
        public virtual PlaneStation PlaneStation { get; set; }

        public DateTime? ArrivalTime { get; set; }
        public DateTime? DepartureTime { get; set; }
        public int? StandingTime { get; set; } 
        public int DistanceFromStart { get; set; } 
    }
}
