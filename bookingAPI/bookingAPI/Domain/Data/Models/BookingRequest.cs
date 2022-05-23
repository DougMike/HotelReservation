using bookingAPI.Data.DomainObjects;
using bookingAPI.Models;

namespace bookingAPI.Domain.Data.Models
{
    public class BookingRequest : Entity
    {
        public Booking Booking { get; set; }
        public Guest Guest { get; set; }
        public Room Room { get; set; }
    }
}
