using Domain.Entities.Abstractions;

namespace Domain.Entities.Peoples
{
    public class Learner : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
