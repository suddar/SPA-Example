namespace SPA_Example.Architecture.Domain.Entities
{
    public class Topic : BaseEntity
    {
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
