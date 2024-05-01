using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Domain.Entities.TrainEntities
{
    public class TrainStationSchedule
    {
        [Key]
        public int Id { get; set; }
        public int TrainStationId { get; set; }
        public virtual TrainStation TrainStation { get; set; }
        public DateTime ScheduleDate { get; set; } 

        public virtual ICollection<TrainArrivalDeparture> TrainMovements { get; set; }
    }
}
