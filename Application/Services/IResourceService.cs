namespace Application.Services
{
    public interface IResourceService
    {
        void DeleteResource(int id);
        Task<IEnumerable<ResourceObject>> GetResources(int page, int count);
        Task UpdateResource(int id, IFormFile file);
        Task<int> UploadResourceAsync(IFormFile file);
    }
}