using bookingAPI.Models;
using bookingAPI.Services.IServices;
using bookingAPI.Services.Validator;
using Microsoft.AspNetCore.Mvc;

namespace bookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("bookings")]
        public IEnumerable<Booking> GetReservations()
        {
            return _bookingService.GetAll();
        }

        [HttpGet("bookings-active-by-document")]
        public IEnumerable<Booking> GetActivesByDocument(string document)
        {
            return _bookingService.GetActivesByDocument(document);
        }

        [HttpPost("booking")]
        public IActionResult AddReservation(Booking booking)
        {
            if (booking == null)
                return NotFound();

            booking.EndDate = booking.EndDate.AddDays(1).AddSeconds(-1);

            return Execute(() => _bookingService.Add<BookingValidator>(booking).Id);

        }

        [HttpPatch("booking")]
        public IActionResult CancelBooking(string document, DateTime startDate)
        {
            var booking = _bookingService.GetByDocDate(document, startDate);
            
            if (booking == null)
                return NotFound();
            
            return Execute(() => _bookingService.Update<BookingValidator>(booking).Id);

        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
