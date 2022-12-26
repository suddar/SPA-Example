using Domain.Entities.Abstractions;

namespace Domain.Entities.Peoples
{
    public class Teacher : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
