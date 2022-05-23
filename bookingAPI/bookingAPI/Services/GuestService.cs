using bookingAPI.Infra.IRepository;
using bookingAPI.Models;
using bookingAPI.Services.IServices;
using FluentValidation;

namespace bookingAPI.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _guestRepository;
        public GuestService(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public Guest Add<TValidator>(Guest guest) where TValidator : AbstractValidator<Guest>
        {
            Validate(guest, Activator.CreateInstance<TValidator>());

            _guestRepository.Add(guest);
            return guest;
        }

        public void Delete(Guest entity) => _guestRepository.Delete(entity);

        public IEnumerable<Guest> GetAll() => _guestRepository.GetAll();

        public Guest GetById(Guid id) => _guestRepository.GetById(id);

        public Guest Update<TValidator>(Guest guest) where TValidator : AbstractValidator<Guest>
        {
            Validate(guest, Activator.CreateInstance<TValidator>());
            _guestRepository.Update(guest);
            return guest;
        }

        private void Validate(Guest guest, AbstractValidator<Guest> validator)
        {
            if (guest == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(guest);
        }

        public Guest GetGuest(string email, string document) => _guestRepository.GetGuest(email, document);

        public void Dispose() => _guestRepository.Dispose();


    }
}
