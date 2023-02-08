using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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
        // TODO change later
        [SupportedOSPlatform("windows")]
        public async Task<int> UploadResourceAsync(IFormFile file)
        {
            var fileType = GetFileType(file.FileName);

            // save uploaded file
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine("resources", fileType, fileName);
            await _fileService.SaveFileAsync(file, Path.Combine(_webRootPath, filePath));

            // save thumbnail
            var thumbnailName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var thumbnailPath = Path.Combine("resources", fileType, thumbnailName);
            var thumbnailData = await _thumbnailService.GenerateImage(file, 120, 120);
            await _fileService.SaveFileAsync(thumbnailData, Path.Combine(_webRootPath, thumbnailPath));

            // create and save new ResourceObject
            var resource = new ResourceObject
            {
                FileName = file.FileName,
                FileType = fileType ?? "",
                FilePath = filePath.Replace("\\", "/"),
                ThumbnailPath = thumbnailPath.Replace("\\", "/"),
            };

            // add and save new entity
            await _dbContext.AddAsync(resource);
            await _dbContext.SaveChangesAsync();
            return resource.Id;
        }
        #endregion

        #region Read
        public async Task<IEnumerable<ResourceObject>> GetResourcesAsync(int page, int count)
        {
            return await _dbContext.ResourceObjects
                .Skip((page - 1) * count)
                .Take(count)
                .ToListAsync();
        }

        public async Task<int> GetPageTotal(int itemsPerPage)
        {
            int totalItems = await _dbContext.ResourceObjects.CountAsync();
            int totalPages = (int)Math.Ceiling(totalItems / (double)itemsPerPage);
            return totalPages;
        }
        #endregion

        #region Update
        public async Task UpdateResourceAsync(int id, IFormFile file)
        {
            var resource = _dbContext.ResourceObjects.Find(id);
            if (resource != null)
            {
                // delete file and thumbnail
                DeleteOldFiles(resource);

                // get file type
                var fileType = GetFileType(file.FileName);

                // save uploaded file
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine("resources", fileType, fileName);
                await _fileService.SaveFileAsync(file, Path.Combine(_webRootPath, filePath));

                // save thumbnail
                var thumbnailName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var thumbnailPath = Path.Combine("resources", fileType, thumbnailName);
                var thumbnailData = await _thumbnailService.GenerateImage(file, 120, 120);
                await _fileService.SaveFileAsync(thumbnailData, Path.Combine(_webRootPath, thumbnailPath));

                // update data
                resource.FileName = file.FileName;
                resource.FileType = GetFileType(file.FileName);
                resource.FilePath = filePath.Replace("\\", "/");
                resource.ThumbnailPath = thumbnailPath.Replace("\\", "/");

                // update and save
                _dbContext.ResourceObjects.Update(resource);
                await _dbContext.SaveChangesAsync();
            }
        }
        #endregion

        #region Delete
        public async Task DeleteResource(int id)
        {
            var resource = await _dbContext.ResourceObjects.FindAsync(id);
            if (resource != null)
            {
                // delete file and thumbnail
                DeleteOldFiles(resource);

                // remove entity
                _dbContext.Remove(resource);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAllResources()
        {
            var resources = _dbContext.ResourceObjects.ToList();
            foreach (var resource in resources)
            {
                await DeleteResource(resource.Id);
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

        private void DeleteOldFiles(ResourceObject resource)
        {
            if (resource.FilePath != null)
                _fileService.DeleteFile(resource.FilePath);

            if (resource.ThumbnailPath != null)
                _fileService.DeleteFile(resource.ThumbnailPath);
        }
        #endregion
    }
}