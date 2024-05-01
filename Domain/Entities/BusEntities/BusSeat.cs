﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.BusEntities
{
    public class BusSeat
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public bool IsAvailable { get; set; }

        public int BusId { get; set; }
        public virtual Bus Bus { get; set; }
    }
}