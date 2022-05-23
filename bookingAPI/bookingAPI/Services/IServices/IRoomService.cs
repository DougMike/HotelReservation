namespace bookingAPI.Services.IServices
{
    public interface IRoomService : IBaseService<Room>
    {
        Room GetByRoomNumber(string roomNumber);
    }
}
