namespace SPA_Example.Architecture.Application.Commands
{
    public class UpdateTopicRequest : BaseRequest, IRequest<object?>
    {
        public UpdateTopicRequest(Command command) : base(command)
        {
        }
    }

    public class UpdateTopicRequestHandler : BaseCommandHandler, IRequestHandler<UpdateTopicRequest, object?>
    {
        public UpdateTopicRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(UpdateTopicRequest request, CancellationToken cancellationToken)
        {
            var requestData = request?.RequestData?.ToString();
            if (request == null || requestData == null) return default;

            return new { };
        }
    }
}
