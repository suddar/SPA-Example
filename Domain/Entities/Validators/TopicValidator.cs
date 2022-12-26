using FluentValidation;
using Domain.Entities.LearningUnits;

namespace Domain.Entities.Validators
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
