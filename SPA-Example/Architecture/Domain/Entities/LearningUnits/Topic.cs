using SPA_Example.Architecture.Domain.Entities.Abstractions;

namespace SPA_Example.Architecture.Domain.Entities.LearningUnits
{
    /// <summary>
    /// Addition, Comparing, Counting, Functions and equations...
    /// </summary>
    public class Topic : BaseEntity
    {
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
