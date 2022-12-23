using Microsoft.EntityFrameworkCore;

namespace SPA_Example.Architecture.Application.Services
{
    public class ResourceService : IResourceService
    {
        readonly AppDbContext _dbContext;
        public ResourceService(AppDbContext dbContext) { _dbContext = dbContext; }


        public async Task<List<ResourceObject>> GetResourceObjects()
        {
            return await _dbContext.ResourceObjects.ToListAsync();
        }

        public async Task SaveAsync(ResourceObject resource)
        {
            await _dbContext.AddAsync(resource);
            await _dbContext.SaveChangesAsync();
        }
    }
}