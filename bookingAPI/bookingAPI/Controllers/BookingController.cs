using bookingAPI.Models;
using bookingAPI.Services;
using bookingAPI.Services.Validator;
using Microsoft.AspNetCore.Mvc;

namespace bookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBaseService<Booking> _bookingService;
        public BookingController(IBaseService<Booking> bookingService)
        {
            _bookingService = bookingService;

        }
        [HttpGet("bookings")]
        public IEnumerable<Booking> GetReservations()
        {
            return _bookingService.GetAll();
        }

        [HttpPost("booking")]
        public IActionResult AddReservation([FromQuery]Booking booking)
        {
            if (booking == null)
                return NotFound();

            return Execute(() => _bookingService.Add<BookingValidator>(booking).Id);
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
                return BadRequest(ex);
            }
        }
    }
}
