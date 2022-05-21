using bookingAPI.Data.DomainObjects;

namespace bookingAPI.Models
{
    public class Guest : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
    }
}
