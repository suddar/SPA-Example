using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Runtime.Versioning;

namespace Application.Services
{
    public class ResourceService : IResourceService
    {
        #region Define
        private readonly string _webRootPath;
        private readonly AppDbContext _dbContext;
        private readonly IFileService _fileService;
        private readonly IThumbnailService _thumbnailService;

        public ResourceService(IWebHostEnvironment env, AppDbContext context, IFileService fileService, IThumbnailService thumbnailService)
        {
            _webRootPath = env.WebRootPath;
            _dbContext = context;
            _fileService = fileService;
            _thumbnailService = thumbnailService;
        }
        #endregion

        #region Public methods
        #region Create
        [SupportedOSPlatform("windows")]
        public async Task<int> UploadResourceAsync(IFormFile file)
        {
            var fileType = GetFileType(file.FileName);

            // save uploaded file
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_webRootPath, "resources", fileType, fileName);
            await _fileService.SaveFileAsync(file, filePath);

            // save thumbnail
            var thumbnailName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var thumbnailPath = Path.Combine(_webRootPath, "resources", fileType, thumbnailName);
            var thumbnailStream = await _thumbnailService.GenerateImage(file, 120, 120);
            _fileService.SaveFile(thumbnailStream, thumbnailPath);

            // create and save new ResourceObject
            var resource = new ResourceObject
            {
                FileName = file.FileName,
                FileType = fileType,
                FilePath = filePath,
                ThumbnailPath = thumbnailPath
            };

            await _dbContext.AddAsync(resource);
            await _dbContext.SaveChangesAsync();
            return resource.Id;
        }
        #endregion

        #region Read
        public async Task<IEnumerable<ResourceObject>> GetResources(int page, int count)
        {
            return await _dbContext.ResourceObjects
                .Skip((page - 1) * count)
                .Take(count)
                .ToListAsync();
        }
        #endregion

        #region Update
        public async Task UpdateResource(int id, IFormFile file)
        {
            var resource = _dbContext.ResourceObjects.Find(id);
            if (resource != null)
            {
                var filePath = resource.FilePath;
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                resource.FileName = file.FileName;
                resource.FileType = GetFileType(file.FileName);
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                filePath = Path.Combine(_webRootPath, "resources", resource.FileType, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                resource.FilePath = filePath;
                _dbContext.ResourceObjects.Update(resource);
                await _dbContext.SaveChangesAsync();
            }
        }
        #endregion

        #region Delete
        public async void DeleteResource(int id)
        {
            var resource = await _dbContext.ResourceObjects.FindAsync(id);
            if (resource != null)
            {
                var filePath = resource.FilePath;
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                _dbContext.Remove(resource);
                await _dbContext.SaveChangesAsync();
            }
        }
        #endregion
        #endregion

        #region Private methods
        private static string GetFileType(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLower();
            if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
            {
                return "images";
            }
            else if (extension == ".mp4" || extension == ".avi")
            {
                return "videos";
            }
            else if (extension == ".mp3" || extension == ".wav")
            {
                return "audios";
            }
            else
            {
                throw new Exception("Invalid file type.");
            }
        }
        #endregion
    }
}