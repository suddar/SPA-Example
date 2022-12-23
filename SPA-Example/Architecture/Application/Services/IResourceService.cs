namespace SPA_Example.Architecture.Application.Services
{
    public interface IResourceService
    {
        Task<List<ResourceObject>> GetResourceObjects();
        Task SaveAsync(ResourceObject resource);
    }
}