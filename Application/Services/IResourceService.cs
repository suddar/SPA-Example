namespace Application.Services
{
    public interface IResourceService
    {
        Task<List<ResourceObject>?> ClearAll();
        Task<List<ResourceObject>> GetResourceObjectsAsync();
        Task SaveAsync(ResourceObject resource);
        Task SaveAsync(IFormFile file);
    }
}