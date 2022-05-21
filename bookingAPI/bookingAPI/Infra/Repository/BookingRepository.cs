using bookingAPI.Data.Context;
using bookingAPI.Data.Repository;
using bookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace bookingAPI.Infra.Repository
{
    public class BookingRepository : IRepository<Booking>
    {
        private readonly HotelContext _hotelContext;
        public BookingRepository(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;

        }
        public IEnumerable<Booking> GetAll()
        {
            return _hotelContext.Bookings.ToList();
        }

        public Booking GetById(Guid id)
        {
            return _hotelContext.Set<Booking>().First(r => r.Id == id);
        }


        public void Add(Booking entity)
        {
            _hotelContext.Set<Booking>().AddAsync(entity);
            _hotelContext.SaveChanges();
        }

        public void Update(Booking entity)
        {
            _hotelContext.Entry(entity).State = EntityState.Modified;
            _hotelContext.SaveChanges();
        }

        public void Delete(Booking entity)
        {
            _hotelContext.Set<Booking>().Remove(entity);
            _hotelContext.SaveChanges();
        }

        public void Dispose()
        {
            _hotelContext.Dispose();
        }
    }
}
