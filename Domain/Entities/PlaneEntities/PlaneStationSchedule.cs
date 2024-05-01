using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Domain.Entities.PlaneEntities
{
    public class PlaneStationSchedule
    {
        [Key]
        public int Id { get; set; }
        public int PlaneStationId { get; set; }
        public virtual PlaneStation PlaneStation { get; set; }
        public DateTime ScheduleDate { get; set; } 

        public virtual ICollection<PlaneArrivalDeparture> PlaneMovements { get; set; }
    }
}
