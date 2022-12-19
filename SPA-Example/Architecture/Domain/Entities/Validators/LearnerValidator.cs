using FluentValidation;
using SPA_Example.Architecture.Domain.Entities.Peoples;

namespace SPA_Example.Architecture.Domain.Entities.Validators
{
    public class LearnerValidator:AbstractValidator<Learner>
    {
        public LearnerValidator() { }
    }
}
