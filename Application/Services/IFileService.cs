namespace Application.Services
{
    public interface IFileService
    {
        void DeleteFile(string filePath);
        Task SaveFileAsync(IFormFile file, string path);
    }
}