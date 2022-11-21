namespace Fullstack_Example.Architecture.Application.Commands.Abstractions
{
    public abstract class BaseRequestHandler
    {
        protected readonly AppDbContext dbContext;
        protected readonly IMapper mapper;
        public BaseRequestHandler(IServiceProvider serviceProvider)
        {
            dbContext = serviceProvider.GetRequiredService<AppDbContext>();
            mapper = serviceProvider.GetRequiredService<IMapper>();
        }
    }
}
