using SPA_Example.Architecture.Domain.Entities.Abstractions;

namespace SPA_Example.Architecture.Domain.Entities.Peoples
{
    public class Learner : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
