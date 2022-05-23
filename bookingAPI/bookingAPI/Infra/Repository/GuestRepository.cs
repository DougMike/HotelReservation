using bookingAPI.Data.Context;
using bookingAPI.Infra.IRepository;
using bookingAPI.Models;

namespace bookingAPI.Infra.Repository
{
    public class GuestRepository : IGuestRepository
    {
        private readonly HotelContext _hotelContext;
        public GuestRepository(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }
        public IEnumerable<Guest> GetAll()
        {
            return _hotelContext.Guests.ToList();
        }

        public Guest GetById(Guid id)
        {
            return _hotelContext.Guests.Where(x => x.Id == id).First();
        }

        public Guest GetGuest(string email, string document)
        {
            return _hotelContext.Guests.Where(g => g.Email == email && g.Document == document).FirstOrDefault();

        }
        public void Add(Guest entity)
        {
            _hotelContext.Guests.Add(entity);
            _hotelContext.SaveChanges();
        }

        public void Delete(Guest entity)
        {
            _hotelContext.Guests.Remove(entity);
            _hotelContext.SaveChanges();
        }


        public void Update(Guest entity)
        {
            _hotelContext.Guests.Update(entity);
            _hotelContext.SaveChanges();
        }
        public void Dispose()
        {
            _hotelContext.Dispose();
        }
    }
}
