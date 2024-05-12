﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.LocationEntities;

namespace Domain.Entities.BusEntities
{
    public class BusStation
    {
        [Key]
        public int Id { get; set; }
        public string StationName { get; set; }

        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public virtual ICollection<BusMovement> BusMovements { get; set; }
    }
}
