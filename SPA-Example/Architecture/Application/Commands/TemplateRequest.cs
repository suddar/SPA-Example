namespace SPA_Example.Architecture.Application.Commands
{
    public class TemplateRequest : BaseRequest, IRequest<object?>
    {
        public TemplateRequest(Command command) : base(command)
        {
        }
    }

    public class TemplateRequestHandler : BaseRequestHandler, IRequestHandler<TemplateRequest, object?>
    {
        public TemplateRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(TemplateRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new { });
        }
    }
}
