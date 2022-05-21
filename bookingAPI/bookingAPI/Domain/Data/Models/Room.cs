using bookingAPI.Data.DomainObjects;
using bookingAPI.Models;

namespace bookingAPI
{
    public class Room : Entity
    {
        public int RoomNumber { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
        
    }
}
