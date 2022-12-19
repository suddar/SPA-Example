using FluentValidation;
using SPA_Example.Architecture.Domain.Entities.LearningUnits;

namespace SPA_Example.Architecture.Domain.Entities.Validators
{
    public class EnrollmentValidator : AbstractValidator<Enrollment>
    {
        public EnrollmentValidator() { }
    }
}
