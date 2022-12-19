using SPA_Example.Architecture.Domain.Entities.Abstractions;

namespace SPA_Example.Architecture.Domain.Entities.Peoples
{
    public class Teacher : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
