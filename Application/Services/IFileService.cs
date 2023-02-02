namespace Application.Services
{
    public interface IFileService
    {
        void DeleteFile(string filePath);
        void SaveFile(MemoryStream ms, string path);
        Task SaveFileAsync(IFormFile file, string path);
    }
}