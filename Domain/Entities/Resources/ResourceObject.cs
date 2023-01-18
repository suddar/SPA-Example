namespace Domain.Entities.Resources
{
    public class ResourceObject : BaseEntity
    {
        public string? FileName { get; set; }
        public string? FilePath { get; set; }

        public string? ContentType { get; set; }
        public byte[]? Thumbnai { get; set; }
        public byte[]? Data { get; set; }

        public string? FileType { get; set; }
        public string? WebRootPath { get; set; }
    }
}