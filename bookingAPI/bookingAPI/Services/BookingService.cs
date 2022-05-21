using bookingAPI.Data.Context;
using bookingAPI.Data.Repository;
using bookingAPI.Infra.IRepository;
using bookingAPI.Infra.Repository;
using bookingAPI.Models;
using FluentValidation;

namespace bookingAPI.Services
{
    public class BookingService : IBaseService<Booking>
    {
        private readonly IRepository<Booking> _bookingRepository;
        private readonly IGuestRepository _guestRepository;
        public BookingService(IRepository<Booking> bookingRepository,
            IGuestRepository guestRepository)
        {
            _bookingRepository = bookingRepository;
            _guestRepository = guestRepository;
        }
        public Booking Add<TValidator>(Booking booking) where TValidator : AbstractValidator<Booking>
        {
            Validate(booking, Activator.CreateInstance<TValidator>());
            
            _bookingRepository.Add(booking);
            return booking;
        }

        public void Delete(Booking entity) => _bookingRepository.Delete(entity);

        public IEnumerable<Booking> GetAll() => _bookingRepository.GetAll();

        public Booking GetById(Guid id) => _bookingRepository.GetById(id);

        public Booking Update<TValidator>(Booking entity) where TValidator : AbstractValidator<Booking>
        {
            Validate(entity, Activator.CreateInstance<TValidator>());
            _bookingRepository.Update(entity);
            return entity;
        }

        private void Validate(Booking booking, AbstractValidator<Booking> validator)
        {
            if (booking == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(booking);
        }
        public void Dispose()
        {
            _bookingRepository.Dispose();
        }
    }
}
