using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.BusEntities
{
    public class BusMovement
    {
        [Key]
        public int Id { get; set; }
        public int BusStationId { get; set; }
        public virtual BusStation BusStation { get; set; }

        public int BusLineId { get; set; }
        public virtual BusLine BusLine { get; set; } 

        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }

        public int? StandingTime { get; set; }
        public int DistanceFromStart { get; set; }
    }
}
