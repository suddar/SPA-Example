using FluentValidation;
using Domain.Entities.Peoples;

namespace Domain.Entities.Validators
{
    public class TeacherValidator:AbstractValidator<Teacher>
    {
        public TeacherValidator() { }
    }
}
