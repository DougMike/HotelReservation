using bookingAPI.Data.DomainObjects;

namespace bookingAPI.Models
{
    public class Booking : Entity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RoomNumber { get; set; }
        public string GuestName { get; set; }
        public string GuestEmail { get; set; }
        public string GuestDocument { get; set; }

    }
}
