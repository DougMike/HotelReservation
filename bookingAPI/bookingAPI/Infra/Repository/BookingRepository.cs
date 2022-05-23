using bookingAPI.Data.Context;
using bookingAPI.Domain;
using bookingAPI.Infra.IRepository;
using bookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace bookingAPI.Infra.Repository
{
    public class BookingRepository : IBookingRepository
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
            return _hotelContext.Bookings.First(r => r.Id == id);
        }

        public IEnumerable<Booking> GetActivesByDocument(string document)
        {
            return _hotelContext.Bookings.Where(r => r.GuestDocument == document
            && r.Status == BookingStatus.active).ToList();

        }

        public Booking GetByDocDate(string document, DateTime startDate)
        {
            return _hotelContext.Bookings.Where(r => r.GuestDocument == document
            && r.StartDate == startDate
            && r.Status == BookingStatus.active).FirstOrDefault();
        }

        public void Add(Booking entity)
        {
            _hotelContext.Bookings.AddAsync(entity);
            _hotelContext.SaveChanges();
        }

        public void Update(Booking entity)
        {
            _hotelContext.Entry(entity).State = EntityState.Modified;
            _hotelContext.SaveChanges();
        }

        public void Delete(Booking entity)
        {
            _hotelContext.Bookings.Remove(entity);
            _hotelContext.SaveChanges();
        }

        public Booking ValidateConflicts(Booking entity)
        {
            Booking res = _hotelContext.Bookings
            .Where(b => b.RoomNumber == entity.RoomNumber)
            .Where(b => b.EndDate >= entity.StartDate)
            .Where(b => b.StartDate <= entity.EndDate)
                .FirstOrDefault();

            return res;
        }
        public void Dispose()
        {
            _hotelContext.Dispose();
        }
    }
}
