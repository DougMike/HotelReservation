using bookingAPI.Data.Context;
using bookingAPI.Data.IRepository;
using bookingAPI.Models;
using System.Linq;
using System.Threading.Tasks;

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
            return _hotelContext.Bookings.ToList();
        }

        public async Task<Booking> GetById(Guid id)
        {
            return await _hotelContext.Bookings.FindAsync(id);
        }
        public void Dispose()
        {
            _hotelContext.Dispose();
        }
    }
}
