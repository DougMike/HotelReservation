using bookingAPI.Models;

namespace bookingAPI.Services.IServices
{
    public interface IGuestService : IBaseService<Guest>
    {
        Guest GetGuest(string email, string document);
    }
}
