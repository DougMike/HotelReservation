using bookingAPI.Data.Repository;
using bookingAPI.Domain.Data.Models;

namespace bookingAPI.Infra.IRepository
{
    public interface IBookingRequestRepository : IRepository<BookingRequest>
    {
    }
}
