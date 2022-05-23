using bookingAPI.Models;

namespace bookingAPI.Services.IServices
{
    public interface IBookingService : IBaseService<Booking>
    {
        IEnumerable<Booking> GetActivesByDocument(string doc);
        Booking GetByDocDate(string document, DateTime startDate);
    }
}
