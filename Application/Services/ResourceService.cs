using Microsoft.AspNetCore.Hosting;

namespace Application.Services
{
    public class ResourceService : IResourceService
    {
        private readonly string _webRootPath;
        private readonly AppDbContext _dbContext;

        public ResourceService(IWebHostEnvironment env, AppDbContext context)
        {
            _webRootPath = env.WebRootPath;
            _dbContext = context;
        }

        public async Task<int> UploadResource(IFormFile file)
        {
            var resource = new ResourceObject
            {
                FileName = file.FileName,
                FileType = GetFileType(file.FileName)
            };

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_webRootPath, "resources", resource.FileType, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            resource.FilePath = filePath;
            _dbContext.ResourceObjects.Add(resource);
            _dbContext.SaveChanges();
            return resource.Id;
        }

        public void DeleteResource(int id)
        {
            var resource = _dbContext.ResourceObjects.Find(id);
            if (resource != null)
            {
                var filePath = resource.FilePath;
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                _dbContext.ResourceObjects.Remove(resource);
                _dbContext.SaveChanges();
            }
        }

        private string GetFileType(string fileName)
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
    }
}