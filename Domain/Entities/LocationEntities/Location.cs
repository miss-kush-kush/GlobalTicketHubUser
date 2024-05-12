using Domain.Entities.TrainEntities;
using Domain.Entities.BusEntities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Domain.Entities.LocationEntities
{
    public class Location
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string PostalCode { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<TrainStation> TrainStations { get; set; }
        public virtual ICollection<BusStation> BusStations { get; set; }
    }
}
