using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.TrainDtos
{
    public class TrainLineDto
    {
        public string LineName { get; set; }
        public string Description { get; set; }
        public List<TrainDto> Trains { get; set; }
    }
}
