using FluentValidation;

namespace bookingAPI.Services.Validator
{
    public class RoomValidator : AbstractValidator<Room>
    {
        public RoomValidator()
        {
            RuleFor(c => c.RoomNumber)
                .NotEmpty().WithMessage("Please enter the room number.")
                .NotNull().WithMessage("Please enter the room number.");
        }
    }
}
