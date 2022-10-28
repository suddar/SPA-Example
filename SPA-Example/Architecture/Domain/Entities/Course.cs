namespace SPA_Example.Architecture.Domain.Entities
{
    public class Course : BaseEntity
    {
        public int TopicId { get; set; }
        public Topic? Topic { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
