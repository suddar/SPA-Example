using FluentValidation;
using Domain.Entities.LearningUnits;

namespace Domain.Entities.Validators
{
    public class EnrollmentValidator : AbstractValidator<Enrollment>
    {
        public EnrollmentValidator() { }
    }
}
