namespace Application.Services
{
    public interface IFileService
    {
        void DeleteFile(string filePath);
        Task SaveFileAsync(byte[] data, string path);
        Task SaveFileAsync(IFormFile file, string path);
    }
}