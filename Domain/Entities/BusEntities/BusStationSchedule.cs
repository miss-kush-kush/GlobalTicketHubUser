using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Domain.Entities.BusEntities
{
    public class BusStationSchedule
    {
        [Key]
        public int Id { get; set; }
        public int BusStationId { get; set; }
        public virtual BusStation BusStation { get; set; }
        public DateTime ScheduleDate { get; set; } 

        public virtual ICollection<BusArrivalDeparture> BusMovements { get; set; }
    }
}
