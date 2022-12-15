using FluentValidation;

namespace SPA_Example.Architecture.Domain.Entities
{
    public class TopicValidator : AbstractValidator<Topic>
    {
        public TopicValidator()
        {
            RuleFor(topic => topic.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(5);
        }
    }
}
