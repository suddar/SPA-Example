namespace SPA_Example.Architecture.Domain.Entities.Resources
{
    public class ResourceObject : BaseEntity
    {
        public string? ContentType { get; set; }
        public byte[]? Bytes { get; set; }
    }
}
