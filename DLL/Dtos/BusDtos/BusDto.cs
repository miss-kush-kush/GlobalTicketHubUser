﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.BusDtos
{
    public class BusDto
    {
        public int BusId { get; set; }
        public string BusType { get; set; }
        public object Seats { get; set; }
    }
}
