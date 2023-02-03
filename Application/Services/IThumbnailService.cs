namespace Application.Services
{
    public interface IThumbnailService
    {
        Task<byte[]> GenerateImage(IFormFile file, int width, int height);
    }
}