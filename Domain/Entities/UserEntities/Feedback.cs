using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.UserEntities
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
        public DateTime DatePosted { get; set; }

        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
    }


}
