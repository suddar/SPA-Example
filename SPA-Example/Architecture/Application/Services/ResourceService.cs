using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Drawing;
using System.Runtime.Versioning;

namespace SPA_Example.Architecture.Application.Services
{
    public class ResourceService : IResourceService
    {
        readonly AppDbContext _dbContext;
        public ResourceService(AppDbContext dbContext) { _dbContext = dbContext; }


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
            if (file == null) throw new ArgumentNullException();

            using MemoryStream ms = new();
            await file.CopyToAsync(ms);

            var resource = new ResourceObject
            {
                Name = file.FileName,
                ContentType = file.ContentType,
                Thumbnai = GenerateImage(ms),
                Bytes = ms.ToArray()
            };

            await SaveAsync(resource);
        }

        [SupportedOSPlatform("windows")]
        private static byte[] GenerateImage(MemoryStream ms)
        {
            Image image = Image.FromStream(ms);
            var thumbnaiImage = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);

            using var thumbnaiStream = new MemoryStream();
            thumbnaiImage.Save(thumbnaiStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            thumbnaiImage.Dispose();

            return thumbnaiStream.ToArray();
        }
    }
}