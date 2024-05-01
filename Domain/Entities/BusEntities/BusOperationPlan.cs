using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Domain.Entities.BusEntities
{
    public class BusOperationPlan
    {
        [Key]
        public int Id { get; set; }
        public int BusLineId { get; set; } 
        public virtual BusLine BusLine { get; set; } 
        public virtual ICollection<BusStop> BusStops { get; set; }
    }
}
