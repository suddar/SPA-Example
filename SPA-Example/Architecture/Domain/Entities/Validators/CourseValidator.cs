using FluentValidation;
using SPA_Example.Architecture.Domain.Entities.LearningUnits;

namespace SPA_Example.Architecture.Domain.Entities.Validators
{
    class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator() { }
    }
}
