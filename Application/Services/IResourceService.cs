namespace Application.Services
{
    public interface IResourceService
    {
        Task DeleteAllResources();
        Task DeleteResource(int id);
        Task<int> GetPageTotal(int count);
        Task<IEnumerable<ResourceObject>> GetResourcesAsync(int page, int count);
        Task UpdateResourceAsync(int id, IFormFile file);
        Task<int> UploadResourceAsync(IFormFile file);
    }
}