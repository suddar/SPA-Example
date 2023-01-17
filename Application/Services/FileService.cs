using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void DeleteFile(string filePath)
        {
            if (File.Exists(_environment.WebRootPath + filePath))
                File.Delete(_environment.WebRootPath + filePath);
        }
    }
}
