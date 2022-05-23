using bookingAPI.Data.Context;
using bookingAPI.Infra.IRepository;

namespace bookingAPI.Infra.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext _hotelContext;
        public RoomRepository(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }
        public void Add(Room Entity)
        {
            _hotelContext.Rooms.Add(Entity);
            _hotelContext.SaveChanges();
        }

        public void Delete(Room entity)
        {
            _hotelContext.Rooms.Remove(entity);
            _hotelContext.SaveChanges();
        }


        public IEnumerable<Room> GetAll()
        {
            return _hotelContext.Rooms.ToList();
        }

        public Room GetById(Guid id)
        {
            return _hotelContext.Rooms.Where(r => r.Id == id).FirstOrDefault();
        }

        public Room GetByRoomNumber(string roomNumber)
        {
            return _hotelContext.Rooms.Where(r => r.RoomNumber == roomNumber).FirstOrDefault();
        }

        public void Update(Room entity)
        {
            _hotelContext.Rooms.Update(entity);
            _hotelContext.SaveChanges();
        }
        public void Dispose()
        {
            _hotelContext.Dispose();
        }
    }
}
