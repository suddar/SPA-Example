namespace SPA_Example.Architecture.Application.Commands
{
    public class GetTopicByIdRequest : BaseRequest
    {
        public GetTopicByIdRequest(Command command) : base(command)
        {
        }
    }

    public class GetTopicByIdRequestHandler : BaseRequestHandler, IRequestHandler<GetTopicByIdRequest, object?>
    {
        public GetTopicByIdRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(GetTopicByIdRequest request, CancellationToken cancellationToken)
        {
            var requestData = request?.RequestData?.ToString();
            if (request == null || requestData == null) return default;

            return new { };
        }
    }
}
