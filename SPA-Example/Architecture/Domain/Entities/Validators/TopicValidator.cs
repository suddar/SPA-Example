using FluentValidation;
using SPA_Example.Architecture.Domain.Entities.LearningUnits;

namespace SPA_Example.Architecture.Domain.Entities.Validators
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
