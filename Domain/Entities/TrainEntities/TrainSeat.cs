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
    public class TrainSeat
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public StateType StateType { get; set; }

        public int WagonId { get; set; }
        public virtual Wagon Wagon { get; set; }
    }
}