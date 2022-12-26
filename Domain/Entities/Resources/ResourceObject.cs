namespace Domain.Entities.Resources
{
    public class ResourceObject : BaseEntity
    {
        public string? ContentType { get; set; }
        public byte[]? Thumbnai { get; set; }
        public byte[]? Bytes { get; set; }
    }
}
