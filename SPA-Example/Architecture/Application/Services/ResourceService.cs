namespace SPA_Example.Architecture.Application.Services
{
    public class ResourceService : IResourceService
    {
        readonly AppDbContext _dbContext;
        public ResourceService(AppDbContext dbContext) { _dbContext = dbContext; }
        public async Task SaveAsync(ResourceObject resource)
        {
            await _dbContext.AddAsync(resource);
            _dbContext.SaveChanges();
        }
    }
}
