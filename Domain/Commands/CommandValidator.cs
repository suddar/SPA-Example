using FluentValidation;

namespace Domain.Commands
{
    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty();
            RuleFor(c => c.RequestData).NotNull();
        }
    }
}
