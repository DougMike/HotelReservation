using bookingAPI.Domain.Data.Models;
using bookingAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace bookingAPI.Data.Context
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }

        public DbSet<BookingRequest> BookingRequests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                    e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotelContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            return await this.SaveChangesAsync() > 0;
        }
    }
}
