using bookingAPI.Data.Repository;
using bookingAPI.Models;

namespace bookingAPI.Infra.IRepository
{
    public interface IGuestRepository : IRepository<Guest>
    {
        Guest GetGuest(string email, string document);
    }
}
