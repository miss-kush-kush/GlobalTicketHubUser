using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.PlaneEntities
{
    public class PlaneArrivalDeparture
    {
        [Key]
        public int Id { get; set; }
        public int PlaneStationScheduleId { get; set; }
        public virtual PlaneStationSchedule PlaneStationSchedule { get; set; }

        public int PlaneOperationPlanId { get; set; }
        public virtual PlaneOperationPlan PlaneOperationPlan { get; set; } 
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}
