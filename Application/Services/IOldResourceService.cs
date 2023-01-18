namespace Application.Services
{
    public interface IOldResourceService
    {
        Task<List<ResourceObject>?> ClearAll();
        Task<bool> Delete(int id);
        Task<List<ResourceObject>> GetResourceObjectsAsync();
        Task SaveToDatabaseAsync(ResourceObject resource);
        Task<bool> Update(int id, ResourceObject updateData);
        Task UploadAsync(IFormFile file);
    }
}