using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Runtime.Versioning;

namespace Application.Services
{
    public class ResourceService : IResourceService
    {
        #region Variable Declaration
        private readonly AppDbContext _dbContext;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _environment;
        public ResourceService(AppDbContext dbContext, IWebHostEnvironment environment, IFileService fileService)
        {
            _dbContext = dbContext;
            _environment = environment;
            _fileService = fileService;
        }
        #endregion

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
            ResourceObject? resource = await _dbContext.FindAsync<ResourceObject>(id);
            if (resource == null || resource.FilePath == null) return false;

            _fileService.DeleteFile(resource.FilePath);
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

        [SupportedOSPlatform("windows")]
        public async Task UploadAsync(IFormFile file)
        {
            if (file == null) throw new NullReferenceException();

            var fileName = Guid.NewGuid().ToString() + ".jpg";
            var filePath = Path.Combine(_environment.WebRootPath, "images", fileName);
            await _fileService.SaveFileAsync(file, filePath);

            using MemoryStream ms = new();
            await file.CopyToAsync(ms);

            var resource = new ResourceObject
            {
                Name = file.FileName,
                ContentType = file.ContentType,
                Thumbnai = GenerateThumbnaiImage(ms),
                //Data = ms.ToArray(),
                FilePath = "/images/" + fileName,
            };

            await SaveToDatabaseAsync(resource);
        }

        public async Task SaveToDatabaseAsync(ResourceObject resource)
        {
            await _dbContext.AddAsync(resource);
            await _dbContext.SaveChangesAsync();
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
    }
}