using FluentValidation;
using Domain.Entities.Peoples;

namespace Domain.Entities.Validators
{
    public class LearnerValidator:AbstractValidator<Learner>
    {
        public LearnerValidator() { }
    }
}
