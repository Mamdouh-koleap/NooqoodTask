using FluentValidation;

namespace Application.Features.Reservations.Commands.CreateReserv
{
    public class CreateCommandValidator : AbstractValidator<ReservCreateVM>
    {
        public CreateCommandValidator()
        {
            RuleFor(r => r.CustomerName)
                 .NotEmpty()
                 .NotNull()
                 .MaximumLength(50);

        }
        
    }
}
