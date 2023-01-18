namespace Application.Services
{
    public interface IResourceService
    {
        void DeleteResource(int id);
        Task<int> UploadResource(IFormFile file);
    }
}