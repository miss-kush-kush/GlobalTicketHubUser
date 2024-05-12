using Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.TrainDtos
{
    public class BuyTrainTicketDto
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Price { get; set; }

        public DateTime DateOfPurchase { get; set; }
        public int SeatNumber { get; set; }
        public int WagonNumber { get; set; }
        public string TrainNumber { get; set; }
        public string TrainLineName { get; set; }

        public DateTime TimeOfDeparture { get; set; }
        public DateTime TimeOfArrival { get; set; }
        public string StationOfDeparture { get; set; }
        public string StationOfArrival { get; set; }

        public TicketType TicketType { get; set; }


    }
}
