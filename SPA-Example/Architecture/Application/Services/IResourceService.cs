namespace SPA_Example.Architecture.Application.Services
{
    public interface IResourceService
    {
        Task SaveAsync(ResourceObject resource);
    }
}