using DLL.Dtos.BusDtos;
using Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.BusDtos
{
    public class AppropriateBusLineDto
    {
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public TimeOnly? DepartureTime { get; set; }
        public TimeOnly? ArrivalTime { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public int AvailablePlaces { get; set; }
        public int TotalPlaces { get; set; }
        public TimeOnly Duration { get; set; }
        public string BusNumber { get; set; }
        public string BusLineName { get; set; }
        public string BusLineDescription { get; set; }

        public List<decimal> FirstPrices { get; set; }
        public int BusId { get; set; }
    }
}
