namespace Application.Services
{
    public interface IResourceService
    {
        Task<List<ResourceObject>?> ClearAll();
        Task<bool> Delete(int id);
        Task<List<ResourceObject>> GetResourceObjectsAsync();
        Task SaveAsync(IFormFile file);
        Task SaveAsync(ResourceObject resource);
        Task<bool> Update(int id, ResourceObject updateData);
    }
}