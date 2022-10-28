namespace Fullstack_Example.Architecture.Application.Commands.Abstractions
{
    public abstract class BaseCommandHandler
    {
        protected readonly AppDbContext dbContext;
        protected readonly IMapper mapper;
        public BaseCommandHandler(IServiceProvider serviceProvider)
        {
            dbContext = serviceProvider.GetRequiredService<AppDbContext>();
            mapper = serviceProvider.GetRequiredService<IMapper>();
        }
    }
}
