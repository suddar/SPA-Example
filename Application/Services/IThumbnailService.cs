namespace Application.Services
{
    public interface IThumbnailService
    {
        Task<MemoryStream> GenerateImage(IFormFile file, int width, int height);
    }
}