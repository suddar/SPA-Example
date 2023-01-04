using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Runtime.Versioning;

namespace Application.Services
{
    public class ResourceService : IResourceService
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;
        public ResourceService(AppDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        public async Task<List<ResourceObject>> GetResourceObjectsAsync()
        {
            return await _dbContext.ResourceObjects.ToListAsync();
        }

        public async Task SaveAsync(ResourceObject resource)
        {
            await _dbContext.AddAsync(resource);
            await _dbContext.SaveChangesAsync();
        }

        [SupportedOSPlatform("windows")]
        public async Task SaveAsync(IFormFile file)
        {
            if (file == null) throw new NullReferenceException();

            using MemoryStream ms = new();
            await file.CopyToAsync(ms);

            var fileName = Guid.NewGuid().ToString() + ".jpg";
            var imagePath = Path.Combine(_environment.WebRootPath, "images", fileName);

            var directory = Path.GetDirectoryName(imagePath);
            if (directory != null && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            using var stream = new FileStream(imagePath, FileMode.Create);
            await file.CopyToAsync(stream);

            var resource = new ResourceObject
            {
                Name = file.FileName,
                ContentType = file.ContentType,
                Thumbnai = GenerateThumbnaiImage(ms),
                //Data = ms.ToArray(),
                FilePath = "/images/" + fileName,
            };

            await SaveAsync(resource);
        }

        [SupportedOSPlatform("windows")]
        private static byte[] GenerateThumbnaiImage(MemoryStream ms)
        {
            Image image = Image.FromStream(ms);
            var thumbnaiImage = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);

            using var thumbnaiStream = new MemoryStream();
            thumbnaiImage.Save(thumbnaiStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            thumbnaiImage.Dispose();

            return thumbnaiStream.ToArray();
        }

        public async Task<List<ResourceObject>?> ClearAll()
        {
            await _dbContext.ResourceObjects.ForEachAsync(resource => _dbContext.Remove(resource));
            await _dbContext.SaveChangesAsync();
            return await _dbContext.ResourceObjects.ToListAsync();
        }
    }
}