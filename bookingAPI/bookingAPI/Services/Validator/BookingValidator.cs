using bookingAPI.Models;
using FluentValidation;

namespace bookingAPI.Services.Validator
{
    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
            RuleFor(c => c.GuestName)
                .NotEmpty().WithMessage("Please enter the name.")
                .NotNull().WithMessage("Please enter the name.");

            RuleFor(c => c.GuestEmail)
                .NotEmpty().WithMessage("Please enter the email.")
                .NotNull().WithMessage("Please enter the email.");

            RuleFor(c => c.GuestDocument)
                .NotEmpty().WithMessage("Please enter the password.")
                .NotNull().WithMessage("Please enter the password.");
            
            RuleFor(c => c.StartDate)
                .NotEmpty().WithMessage("Please enter the inicial day.")
                .NotNull().WithMessage("Please enter the inicial day.");
            
            RuleFor(c => c.EndDate)
                .NotEmpty().WithMessage("Please enter the final day.")
                .NotNull().WithMessage("Please enter the final day.");
        }
    }
}
