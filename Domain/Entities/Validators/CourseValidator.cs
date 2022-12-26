using FluentValidation;
using Domain.Entities.LearningUnits;

namespace Domain.Entities.Validators
{
    class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator() { }
    }
}
