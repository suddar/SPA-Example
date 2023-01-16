using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
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

        #region API public methods
        public async Task<List<ResourceObject>?> ClearAll()
        {
            await _dbContext.ResourceObjects.ForEachAsync(resource => _dbContext.Remove(resource));
            await _dbContext.SaveChangesAsync();
            return await _dbContext.ResourceObjects.ToListAsync();
        }

        public async Task<List<ResourceObject>> GetResourceObjectsAsync()
        {
            return await _dbContext.ResourceObjects.ToListAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var resource = await _dbContext.FindAsync<ResourceObject>(id);
            if (resource == null) return false;

            _dbContext.Remove(resource);
            return true;
        }

        public async Task<bool> Update(int id, ResourceObject updateData)
        {
            var resource = await _dbContext.FindAsync<ResourceObject>(id);
            if (resource == null) return false;

            resource.CopyFrom(updateData);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Private methods
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
        #endregion

        [SupportedOSPlatform("windows")]
        public async Task UploadAsync(IFormFile file)
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

            //await SaveFileAsync();
            await SaveToDatabaseAsync(resource);
        }

        public async Task SaveToDatabaseAsync(ResourceObject resource)
        {
            await _dbContext.AddAsync(resource);
            await _dbContext.SaveChangesAsync();
        }

    }
}