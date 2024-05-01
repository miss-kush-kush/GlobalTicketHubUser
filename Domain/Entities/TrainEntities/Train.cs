using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Types;

namespace Domain.Entities.TrainEntities
{
    public class Train
    {
        [Key]
        public int Id { get; set; }
        public string TrainNumber { get; set; } 

        public TrainType TrainType { get; set; }    

        public int TrainLineId { get; set; }
        public virtual TrainLine TrainLine { get; set; }

        public virtual ICollection<Wagon> Wagons { get; set; }
    }
}
