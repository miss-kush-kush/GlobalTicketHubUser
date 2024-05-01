using Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.PlaneEntities
{
    public class PlaneLine
    {
        [Key]
        public int Id { get; set; }
        public string LineName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Plane> Planes { get; set; }  
        public virtual ICollection<PlaneOperationPlan> PlaneOperationPlans { get; set; }
    }
}
