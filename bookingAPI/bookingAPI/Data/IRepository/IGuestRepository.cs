using bookingAPI.Data.Repository;
using bookingAPI.Models;
using System.Linq.Expressions;

namespace bookingAPI.Data.IRepository
{
    public interface IGuestRepository : IRepository<Guest>
    {
    }
}
