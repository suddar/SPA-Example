using FluentValidation;
using Domain.Entities.LearningUnits;

namespace Domain.Entities.Validators
{
    public class SubjectValidator : AbstractValidator<Subject>
    {
        public SubjectValidator() { }
    }
}
