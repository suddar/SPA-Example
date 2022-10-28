namespace SPA_Example.Architecture.Application.Commands
{
    public class DeleteSkillRequest : BaseRequest, IRequest<object?>
    {
        public DeleteSkillRequest(Command command) : base(command)
        {
        }
    }

    public class DeleteSkillRequestHandler : BaseCommandHandler, IRequestHandler<DeleteSkillRequest, object?>
    {
        public DeleteSkillRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(DeleteSkillRequest request, CancellationToken cancellationToken)
        {
            var requestData = request?.RequestData?.ToString();
            if (request == null || requestData == null) return default;

            return new { };
        }
    }
}
