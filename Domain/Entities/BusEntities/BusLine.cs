﻿using Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.BusEntities
{
    public class BusLine
    {
        [Key]
        public int Id { get; set; }
        public string LineName { get; set; }
        public string Description { get; set; }
        public string Owner {  get; set; }

        public virtual ICollection<Bus> Buses { get; set; }
        public virtual ICollection<BusMovement> BusMovements { get; set; }
    }
}
