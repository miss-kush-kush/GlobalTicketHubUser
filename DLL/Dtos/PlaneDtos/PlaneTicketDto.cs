using Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.PlaneDtos
{
    public class PlaneTicketDto
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

        public PlaneType PlaneType { get; set; }

        public PlaneSeatType PlaneSeatType { get; set; }

        public string PlaneNumber { get; set; }

        public int PlaneSeat { get; set; }
    }
}
