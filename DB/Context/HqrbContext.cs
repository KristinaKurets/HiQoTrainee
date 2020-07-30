using Common.Extension;
using DB.Entity;
using DB.EnttityStatus;
using DB.LookupTable;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DB.Context
{
   
    public class HqrbContext:DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Desk> Desks { get; set; }
        public DbSet<WorkPlan> WorkPlans { get; set; }
        public DbSet<UserPosition> userPositions { get; set; }
        public DbSet<BookingStatusLoockup> BookingStatusLoockups { get; set; }
        public DbSet<UserRoleLoockup> UserRoleLoockups { get; set; }
        public DbSet<DeskStatusLoockup> DeskStatusLoockups { get; set; }
        public DbSet<WorkingDaysCalendar> Calendar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
             .Entity<BookingStatusLoockup>()
             .Property(e => e.ID)
             .HasConversion<short>();

            modelBuilder
                .Entity<BookingStatusLoockup>().HasData(
                    Enum.GetValues(typeof(BookingStatus))
                        .Cast<BookingStatus>()
                        .Select(e => new BookingStatusLoockup()
                        {
                            ID = (short)e,
                            Description = e.GetDescription()
                        })
                );


            modelBuilder
             .Entity<DeskStatusLoockup>()
             .Property(e => e.ID)
             .HasConversion<short>();

            modelBuilder
                .Entity<DeskStatusLoockup>().HasData(
                    Enum.GetValues(typeof(DeskStatus))
                        .Cast<DeskStatus>()
                        .Select(e => new DeskStatusLoockup()
                        {
                            ID = (short)e,
                            Status = e.GetDescription()
                        })
                );
            modelBuilder
                .Entity<UserRoleLoockup>()
                .Property(e => e.ID)
                .HasConversion<short>();

            modelBuilder
                .Entity<UserRoleLoockup>().HasData(
                    Enum.GetValues(typeof(UserRole))
                        .Cast<UserRole>()
                        .Select(e => new UserRoleLoockup()
                        {
                            ID = (short)e,
                            Role = e.GetDescription()
                        })
                );
        }
        public HqrbContext(DbContextOptions<HqrbContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

    }
}
