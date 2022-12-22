using SPA_Example.Architecture.Domain.Entities.Resources;

namespace SPA_Example.Architecture.Application.Commands
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
            //var dd = Validate<ResourceObject>(request);
            Console.WriteLine(request.RequestData);
            return await Task.FromResult(new { });
        }
    }
}
