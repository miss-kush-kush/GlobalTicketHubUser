using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.BusEntities
{
    public class BusArrivalDeparture
    {
        [Key]
        public int Id { get; set; }
        public int BusStationScheduleId { get; set; }
        public virtual BusStationSchedule BusStationSchedule { get; set; }

        public int BusOperationPlanId { get; set; }
        public virtual BusOperationPlan BusOperationPlan { get; set; } 
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}
