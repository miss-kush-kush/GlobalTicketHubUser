using Domain.BusEntities;
using Domain.Entities.BusEntities;
using Domain.Entities.LocationEntities;
using Domain.Entities.TrainEntities;
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
        public DbSet<Order> Orders { get; set; }
        public DbSet<TrainTicket> TrainTickets { get; set; }
        public DbSet<BusTicket> BusTickets { get; set; }
        public DbSet<TrainPurchaseHistory> TrainPurchaseHistory { get; set; }
        public DbSet<BusPurchaseHistory> BusPurchaseHistory { get; set; }

        // Train related DbSets
        public DbSet<TrainLine> TrainLines { get; set; }
        public DbSet<TrainStation> TrainStations { get; set; }
        public DbSet<Wagon> Wagons { get; set; }
        public DbSet<TrainSeat> TrainSeats { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<TrainMovement> TrainMovements { get; set; }
        public DbSet<TrainSchedule> TrainSchedules { get; set; }

        ////Bus related DbSets
        public DbSet<BusLine> BusLines { get; set; }
        public DbSet<BusStation> BusStations { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<BusSeat> BusSeats { get; set; }
        public DbSet<BusMovement> BusMovements { get; set; }

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
