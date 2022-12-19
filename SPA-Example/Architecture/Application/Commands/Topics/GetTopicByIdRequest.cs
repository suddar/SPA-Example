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
            return await Task.FromResult(new { });
        }
    }
}
