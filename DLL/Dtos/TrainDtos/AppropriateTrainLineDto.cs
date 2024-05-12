using Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Dtos.TrainDtos
{
    public class AppropriateTrainLineDto
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
        public TrainType TrainType { get; set; }
        public string TrainNumber { get; set; }
        public string TrainLineName { get; set; }
        public string TrainLineDescription { get; set; }
        public List<WagonType> WagonTypes { get; set; }
        public List<WagonDto> Wagons { get; set; }

        public List<decimal> FirstPrices { get; set; }
        public int TrainId { get; set; }
    }
}
