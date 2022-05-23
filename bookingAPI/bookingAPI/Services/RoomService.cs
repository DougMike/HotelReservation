using bookingAPI.Infra.IRepository;
using bookingAPI.Services.IServices;
using bookingAPI.Services.Validator;
using FluentValidation;

namespace bookingAPI.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public Room GetById(Guid id) => _roomRepository.GetById(id);

        public IEnumerable<Room> GetAll() => _roomRepository.GetAll();

        public Room Add<TValidator>(Room room) where TValidator : AbstractValidator<Room>
        {
            Validate(room, Activator.CreateInstance<RoomValidator>());
            _roomRepository.Add(room);
            return room;
        }

        public void Delete(Room entity) => _roomRepository.Delete(entity);

        public Room Update<TValidator>(Room room) where TValidator : AbstractValidator<Room>
        {
            Validate(room, Activator.CreateInstance<RoomValidator>());
            _roomRepository.Update(room);
            return room;
        }

        public Room GetByRoomNumber(string roomNumber) => _roomRepository.GetByRoomNumber(roomNumber);

        private void Validate(Room room, AbstractValidator<Room> validator)
        {
            if (room == null)
                throw new Exception("Registros não detectados!");

            if(room.RoomNumber != "1")
                throw new Exception("Only room 1 is available!");
            validator.ValidateAndThrow(room);
        }
        public void Dispose() => _roomRepository.Dispose();
    }
}
