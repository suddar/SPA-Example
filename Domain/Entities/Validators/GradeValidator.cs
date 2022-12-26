using Domain.Entities.LearningUnits;
using FluentValidation;

namespace Domain.Entities.Validators
{
    public class GradeValidator : AbstractValidator<Grade>
    {
        public GradeValidator() { }
    }
}
