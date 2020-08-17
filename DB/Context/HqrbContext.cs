using Common.Extension;
using DB.Entity;
using DB.LookupTable;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using DB.EntityStatus;
using RequestLogger.Entities;

namespace DB.Context
{
   
    public class HqrbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Desk> Desks { get; set; }
        public DbSet<WorkPlan> WorkPlans { get; set; }
        public DbSet<UserPosition> UserPositions { get; set; }
        public DbSet<BookingStatusLookup> BookingStatusLookups { get; set; }
        public DbSet<UserRoleLookup> UserRoleLookups { get; set; }
        public DbSet<DeskStatusLookup> DeskStatusLookups { get; set; }
        public DbSet<WorkingDaysCalendar> Calendar { get; set; }
        public DbSet<BadRequestEntity> BadRequestsLog { get; set; }
        public DbSet<RequestProcessingEntity> RequestProcessingLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
             .Entity<BookingStatusLookup>()
             .Property(e => e.ID)
             .HasConversion<short>();

            modelBuilder
                .Entity<BookingStatusLookup>().HasData(
                    Enum.GetValues(typeof(BookingStatus))
                        .Cast<BookingStatus>()
                        .Select(e => new BookingStatusLookup()
                        {
                            ID = (short)e,
                            Description = e.GetDescription()
                        })
                );


            modelBuilder
             .Entity<DeskStatusLookup>()
             .Property(e => e.ID)
             .HasConversion<short>();

            modelBuilder
                .Entity<DeskStatusLookup>().HasData(
                    Enum.GetValues(typeof(DeskStatus))
                        .Cast<DeskStatus>()
                        .Select(e => new DeskStatusLookup()
                        {
                            ID = (short)e,
                            Status = e.GetDescription()
                        })
                );
            modelBuilder
                .Entity<UserRoleLookup>()
                .Property(e => e.ID)
                .HasConversion<short>();

            modelBuilder
                .Entity<UserRoleLookup>().HasData(
                    Enum.GetValues(typeof(UserRole))
                        .Cast<UserRole>()
                        .Select(e => new UserRoleLookup()
                        {
                            ID = (short)e,
                            Role = e.GetDescription()
                        })
                );
            modelBuilder
                .Entity<User>().HasAlternateKey(
                x => x.Email);
        }
        public HqrbContext(DbContextOptions<HqrbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseLazyLoadingProxies();
    }
}
