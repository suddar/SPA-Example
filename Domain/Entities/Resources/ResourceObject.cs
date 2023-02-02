namespace Domain.Entities.Resources
{
    public class ResourceObject : BaseEntity
    {
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileType { get; set; }
        public string? ThumbnailPath { get; set; }
    }
}