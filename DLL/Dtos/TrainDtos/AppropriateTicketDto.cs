using Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.TrainDtos
{
    public class AppropriateTicketDto
    {
        public int Id { get; set; }

        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }

        public DateTime? DepartureTime { get; set; } // hours and minutes 
        public DateTime? ArrivalTime { get; set; }

        public DateTime? DepartureDate { get; set; } // yyyy-mm-dd
        public DateTime? ArrivalDate { get; set; }

        public int AvailablePlaces { get; set; }
        public int TotalPlaces { get; set; }

        public float Duration { get; set; }//date time of arrival - date time of departure

        public TrainType TrainType { get; set; }

        public string TrainLineName { get; set; }

        public string TrainLineDescription { get; set; }
    }
}
