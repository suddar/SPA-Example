using Microsoft.AspNetCore.Hosting;

namespace Application.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;

        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task SaveFileAsync(IFormFile file, string path)
        {
            using MemoryStream ms = new();
            await file.CopyToAsync(ms);

            var directory = Path.GetDirectoryName(path);
            if (directory != null && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
        }

        public void SaveFile(MemoryStream ms, string path)
        {
            FileStream file = new(path, FileMode.Create, FileAccess.Write);
            ms.WriteTo(file);
            file.Close();
            ms.Close();
        }

        public void DeleteFile(string filePath)
        {
            if (File.Exists(_environment.WebRootPath + filePath))
                File.Delete(_environment.WebRootPath + filePath);
        }
    }
}
