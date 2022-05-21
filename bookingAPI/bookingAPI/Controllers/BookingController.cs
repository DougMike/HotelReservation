using bookingAPI.Data.IRepository;
using bookingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace bookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;

        }
        [HttpGet("bookings")]
        public async Task<IEnumerable<Booking>> GetReservations()
        {
            return await _bookingRepository.GetAll();
        }

        [HttpPost("booking")]
        public void AddReservation([FromQuery]Booking booking)
        {
            _bookingRepository.Add(booking);
            

        }
    }
}
