using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Domain.Entities.TrainEntities
{
    public class TrainOperationPlan
    {
        [Key]
        public int Id { get; set; }
        public int TrainLineId { get; set; } 
        public virtual TrainLine TrainLine { get; set; } 
        public virtual ICollection<TrainStop> TrainStops { get; set; }
    }
}
