namespace SPA_Example.Architecture.Application.Commands
{
    public class DeleteUserRequest : BaseRequest, IRequest<object?>
    {
        public DeleteUserRequest(Command command) : base(command)
        {
        }
    }

    public class DeleteUserRequestHandler : BaseCommandHandler, IRequestHandler<TemplateRequest, object?>
    {
        public DeleteUserRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(TemplateRequest request, CancellationToken cancellationToken)
        {
            var requestData = request?.RequestData?.ToString();
            if (request == null || requestData == null) return default;

            return new { };
        }
    }
}
