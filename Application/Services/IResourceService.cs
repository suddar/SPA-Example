namespace Application.Services
{
    public interface IResourceService
    {
        Task<List<ResourceObject>> GetResourceObjectsAsync();
        Task SaveAsync(ResourceObject resource);
        Task SaveAsync(IFormFile file);
    }
}