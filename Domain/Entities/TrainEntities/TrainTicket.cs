﻿using Domain.Entities.UserEntities;
using Domain.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TrainEntities
{
    public class TrainTicket
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public TicketType TicketType { get; set; }

        public int SeatNumber { get; set; }
        public int WagonNumber { get; set; }
        public string TrainNumber { get; set; }
        public string TrainLineName { get; set; }
        public DateTime TimeOfDeparture { get; set; }
        public DateTime TimeOfArrival { get; set; }
        public string StationOfDeparture { get; set; }
        public string StationOfArrival { get; set; }

    }
}
