using Domain.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TrainEntities
{
    public class Wagon
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }  

        public WagonType WagonType { get; set; }

        public int TrainId { get; set; }
        public virtual Train Train { get; set; }

        public virtual ICollection<TrainSeat> TrainSeats { get; set; }
    }
}
