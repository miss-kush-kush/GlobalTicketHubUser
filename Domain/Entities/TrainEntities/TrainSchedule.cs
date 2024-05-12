using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TrainEntities
{
    public class TrainSchedule
    {
        [Key]
        public int Id { get; set; }
        public int TrainStationId { get; set; }
        public virtual TrainStation TrainStation { get; set; }

        public int TrainLineId { get; set; }
        public virtual TrainLine TrainLine { get; set; } // Link back to the general train schedule
        public TimeOnly? ArrivalTime { get; set; }
        public TimeOnly? DepartureTime { get; set; }

        public int? StandingTime { get; set; }
        public int DistanceFromStart { get; set; }
    }
}
