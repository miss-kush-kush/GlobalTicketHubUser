using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.BusEntities
{
    public class Bus
    {
        [Key]
        public int Id { get; set; }
        public string BusNumber { get; set; } 

        public int BusLineId { get; set; }
        public virtual BusLine BusLine { get; set; }

        public virtual ICollection<BusSeat> BusSeats { get; set; }
    }
}
