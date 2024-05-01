using Domain.Entities.LocationEntities;
using Domain.Entities.TrainEntities;
using Domain.Entities.BusEntities;
using Domain.Entities.PlaneEntities;
using Domain.Entities.UserEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace DLL.DbContext
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<TrainTicket> TrainTickets { get; set; }
        public DbSet<BusTicket> BusTickets { get; set; }
        public DbSet<PlaneTicket> PlaneTickets { get; set; }
        public DbSet<BookingHistory> BookingHistories { get; set; }

        // Train related DbSets
        public DbSet<TrainLine> TrainLines { get; set; }
        public DbSet<TrainStation> TrainStations { get; set; }
        public DbSet<TrainStop> TrainStops { get; set; }
        public DbSet<TrainOperationPlan> TrainOperationPlans { get; set; }
        public DbSet<Wagon> Wagons { get; set; }
        public DbSet<TrainSeat> TrainSeats { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<TrainArrivalDeparture> TrainArrivalsDepartures { get; set; }
        public DbSet<TrainStationSchedule> TrainStationSchedules { get; set; }

        //Bus related DbSets
        public DbSet<BusLine> BusLines { get; set; }
        public DbSet<BusStation> BusStations { get; set; }
        public DbSet<BusStop> BusStops { get; set; }
        public DbSet<BusOperationPlan> BusOperationPlans { get; set; }
        public DbSet<BusSeat> BusSeats { get; set; }
        public DbSet<Bus> Buses { get; set; }

        //Plane related DbSets
        public DbSet<PlaneLine> PlaneLines { get; set; }
        public DbSet<PlaneStation> PlaneStations { get; set; }
        public DbSet<PlaneStop> PlaneStops { get; set; }
        public DbSet<PlaneOperationPlan> PlaneOperationPlans { get; set; }
        public DbSet<PlaneSeat> PlaneSeats { get; set; }
        public DbSet<Plane> Planes { get; set; }

        // Location related DbSets
        public DbSet<Country> Countries { get; set; }
        public DbSet<Location> Locations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
