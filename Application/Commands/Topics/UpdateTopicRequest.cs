namespace Application.Commands
{
    public class UpdateTopicRequest : BaseRequest
    {
        public UpdateTopicRequest(Command command) : base(command)
        {
        }
    }

    public class UpdateTopicRequestHandler : BaseRequestHandler, IRequestHandler<UpdateTopicRequest, object?>
    {
        public UpdateTopicRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(UpdateTopicRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new { });
        }
    }
}
