using Domain.Entities.Abstractions;

namespace Domain.Entities.LearningUnits
{
    /// <summary>
    /// Math, Science, Language,...
    /// </summary>
    public class Subject : BaseEntity
    {
        public Skill? Skills { get; set; }
    }
}
