using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.BusDtos
{
    public class BusLineDto
    {
        public string LineName { get; set; }
        public string Description { get; set; }
        public object Buses { get; set; }
    }
}
