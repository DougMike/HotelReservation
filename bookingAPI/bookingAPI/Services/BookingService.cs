using bookingAPI.Domain;
using bookingAPI.Domain.Data.Models;
using bookingAPI.Infra.IRepository;
using bookingAPI.Models;
using bookingAPI.Services.IServices;
using bookingAPI.Services.Validator;
using FluentValidation;

namespace bookingAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IGuestService _guestService;
        private readonly IRoomService _roomService;
        private readonly IBookingRequestRepository _bookingRequestRepository;
        public BookingService(IBookingRepository bookingRepository,
            IGuestService guestService,
            IRoomService roomService,
            IBookingRequestRepository bookingRequestRepository)
        {
            _bookingRepository = bookingRepository;
            _guestService = guestService;
            _roomService = roomService;
            _bookingRequestRepository = bookingRequestRepository;
        }
        public IEnumerable<Booking> GetAll() => _bookingRepository.GetAll();
        public Booking GetById(Guid id) => _bookingRepository.GetById(id);

        public IEnumerable<Booking> GetActivesByDocument(string document) => _bookingRepository.GetActivesByDocument(document);

        public Booking Add<TValidator>(Booking booking) where TValidator : AbstractValidator<Booking>
        {
            Validate(booking, Activator.CreateInstance<TValidator>());
            var bookingRequest = new BookingRequest();

            var guest = _guestService.GetGuest(booking.GuestEmail, booking.GuestDocument);

            if (guest == null)
            {
                Guest newGuest = new Guest()
                {
                    Name = booking.GuestName,
                    Document = booking.GuestDocument,
                    Email = booking.GuestEmail,
                };

                guest = newGuest;

                _guestService.Add<GuestValidator>(guest);
            };


            var room = _roomService.GetByRoomNumber(booking.RoomNumber);

            if (room == null)
            {
                Room newRoom = new Room()
                {
                    RoomNumber = booking.RoomNumber
                };
                room = newRoom;

                _roomService.Add<RoomValidator>(newRoom);
            };

            bookingRequest.Booking = booking;
            bookingRequest.Guest = guest;
            bookingRequest.Room = room;

            _bookingRequestRepository.Add(bookingRequest);

            booking.Status = Domain.BookingStatus.active;
            _bookingRepository.Add(booking);
            return booking;
        }

        public void Delete(Booking entity) => _bookingRepository.Delete(entity);

        public Booking GetByDocDate(string document, DateTime startDate) => _bookingRepository.GetByDocDate(document, startDate);

        public Booking Update<TValidator>(Booking entity) where TValidator : AbstractValidator<Booking>
        {
            if (entity.Status == BookingStatus.active)
                entity.Status = BookingStatus.canceled;

            _bookingRepository.Update(entity);
            return entity;
        }

        private void Validate(Booking booking, AbstractValidator<Booking> validator)
        {
            if (booking == null)
                throw new Exception("Registros não detectados!");

            var existintReservation = _bookingRepository.ValidateConflicts(booking);
            if (existintReservation != null)
            {
                throw new Exception("Reservation with params conflicts. Chose another date interval.");
            }

            if (DateTime.Compare(booking.StartDate, DateTime.Today) <= 0)
                throw new Exception("The start date must be greater than today: " + booking.StartDate);

            if(DateTime.Compare(booking.EndDate,booking.StartDate) <= 0)
                throw new Exception("End date must be greater than Start date. Set it again!");

            if((booking.EndDate - booking.StartDate).TotalDays >= 3)
                throw new Exception("Total days of reservation is not possible. Chose a intervall smaller or equal 3 days");

            if ((booking.StartDate - DateTime.Today).TotalDays >= 30)
                throw new Exception("More than 30 day until the reservation begins. Chose another intervall");

            validator.ValidateAndThrow(booking);
        }
        
        public void Dispose()
        {
            _bookingRepository.Dispose();
        }
    }
}
