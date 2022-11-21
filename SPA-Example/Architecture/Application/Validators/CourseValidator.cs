using FluentValidation;
using System;

namespace SPA_Example.Architecture.Application.Validators
{
    public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(x => x.Content).NotNull().NotEmpty();
        }
    }
}
