using Domain.Entities.Resources;

namespace Application.Commands
{
    public class CreateResourceRequest : BaseRequest, IRequest<object?>
    {
        public CreateResourceRequest(Command command) : base(command)
        {
        }
    }

    public class CreateResourceRequestHandler : BaseRequestHandler, IRequestHandler<CreateResourceRequest, object?>
    {
        public CreateResourceRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(CreateResourceRequest request, CancellationToken cancellationToken)
        {
            var resource = new ResourceObject
            {
                Name = "Testttt"
            };

            await dbContext.AddAsync(resource, cancellationToken).ConfigureAwait(false);
            await dbContext.SaveChangesAsync(cancellationToken);
            return resource;
        }
    }
}
