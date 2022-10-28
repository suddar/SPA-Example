namespace SPA_Example.Architecture.Application.Commands
{
    public class CreateTopicRequest : BaseRequest, IRequest<object?>
    {
        public CreateTopicRequest(Command command) : base(command)
        {
        }
    }

    public class CreateTopicRequestHandler : BaseCommandHandler, IRequestHandler<CreateTopicRequest, object?>
    {
        public CreateTopicRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(CreateTopicRequest request, CancellationToken cancellationToken)
        {
            //var requestData = request?.RequestData?.ToString();
            //if (request == null || requestData == null) return default;
            return new { Message = "OKKKKKKKKK" };
        }
    }
}
