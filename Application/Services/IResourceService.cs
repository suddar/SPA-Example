namespace Application.Services
{
    public interface IResourceService
    {
        void DeleteResource(int id);
        Task<int> GetPageTotal(int count);
        Task<IEnumerable<ResourceObject>> GetResourcesAsync(int page, int count);
        Task UpdateResource(int id, IFormFile file);
        Task<int> UploadResourceAsync(IFormFile file);
    }
}