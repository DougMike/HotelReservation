using bookingAPI.Data.Repository;
using bookingAPI.Models;

namespace bookingAPI.Infra.IRepository
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Booking ValidateConflicts(Booking booking);
        IEnumerable<Booking> GetActivesByDocument(string document);
        Booking GetByDocDate(string document, DateTime startDate);
    }
}
