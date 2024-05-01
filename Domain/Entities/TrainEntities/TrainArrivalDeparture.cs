using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TrainEntities
{
    public class TrainArrivalDeparture
    {
        [Key]
        public int Id { get; set; }
        public int TrainStationScheduleId { get; set; }
        public virtual TrainStationSchedule TrainStationSchedule { get; set; }

        public int TrainOperationPlanId { get; set; }
        public virtual TrainOperationPlan TrainOperationPlan { get; set; } // Link back to the general train schedule
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}
