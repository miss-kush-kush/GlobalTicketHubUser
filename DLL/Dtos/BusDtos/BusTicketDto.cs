using Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.BusDtos
{
    public class BusTicketDto
    {
        public int Id { get; set; }

        public string PassengerFirstName { get; set; }
        public string PassengerLastName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string StudentCardNumber { get; set; }

        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }

        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }

        public decimal Price { get; set; }

        public float Duration { get; set; }

        public BusType BusType { get; set; }

        public string BusNumber { get; set; }
        public int TrainSeat { get; set; }
    }
}
