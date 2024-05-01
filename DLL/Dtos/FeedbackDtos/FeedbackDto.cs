using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.FeedbackDtos
{
    public class FeedbackDto
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
