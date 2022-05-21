using bookingAPI.Data.Context;
using bookingAPI.Data.IRepository;
using bookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace bookingAPI.Data.Repository
{
    public class GuestRepository : IGuestRepository
    {
        private readonly HotelContext _hotelContext;
        public GuestRepository(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public async Task<IEnumerable<Guest>> GetAll()
        {
            return await _hotelContext.Guests
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Guest> GetById(Guid id)
        {
            return await _hotelContext.Guests.FindAsync(id);
        }
        public void Dispose()
        {
            _hotelContext.Dispose();
        }

        public void Add(Guest entity)
        {
            _hotelContext.Guests.AddAsync(entity);
        }
    }
}
