using bookingAPI.Data.Context;
using bookingAPI.Data.IRepository;
using bookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace bookingAPI.Data.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelContext _hotelContext;
        
        public BookingRepository(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }
        public async Task<IEnumerable<Booking>> GetAll()
        {
            return await _hotelContext.Bookings
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Booking> GetById(Guid id)
        {
            return await _hotelContext.Bookings.Where(b => b.Id == id).FirstAsync();
        }
        public void Dispose()
        {
            _hotelContext.Dispose();
        }

        public void Add(Booking booking)
        {
            var gst = _hotelContext.Guests.Where(g => g.Email == booking.GuestEmail).FirstOrDefault();

            if (gst == null)
            {
                Guest guest = new Guest()
                {
                    Name = booking.GuestName,
                    Email = booking.GuestEmail,
                    Document = booking.GuestDocument
                };

                _hotelContext.Guests.AddAsync(guest);
                _hotelContext.SaveChanges();
            }

            Add(booking);

            _hotelContext.SaveChanges();
        }
    }
}
