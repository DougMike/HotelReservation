using bookingAPI.Data.Repository;

namespace bookingAPI.Infra.IRepository
{
    public interface IRoomRepository : IRepository<Room>
    {
        Room GetByRoomNumber(string roomNumber);
    }
}
