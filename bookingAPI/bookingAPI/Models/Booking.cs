using bookingAPI.Data.DomainObjects;

namespace bookingAPI.Models
{
    public class Booking : Entity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Room Room { get; set; }
    }
}
