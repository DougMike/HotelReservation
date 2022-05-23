using bookingAPI.Data.Context;
using bookingAPI.Domain.Data.Models;
using bookingAPI.Infra.IRepository;

namespace bookingAPI.Infra.Repository
{
    public class BookingRequestRepository : IBookingRequestRepository
    {
        private readonly HotelContext _hotelContext;
        public BookingRequestRepository(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }
        public IEnumerable<BookingRequest> GetAll()
        {
            return _hotelContext.BookingRequests.ToList();
        }

        public BookingRequest GetById(Guid id)
        {
            return _hotelContext.BookingRequests.Where(b => b.Id == id).FirstOrDefault();
        }
        public void Add(BookingRequest entity)
        {
            _hotelContext.BookingRequests.Add(entity);
        }

        public void Delete(BookingRequest entity)
        {
            _hotelContext.BookingRequests.Remove(entity);
        }

        public void Update(BookingRequest entity)
        {
            _hotelContext.BookingRequests.Update(entity);
        }
        public void Dispose()
        {
            _hotelContext.Dispose();
        }
    }
}
