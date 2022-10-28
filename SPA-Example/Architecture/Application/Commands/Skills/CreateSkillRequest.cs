namespace SPA_Example.Architecture.Application.Commands
{
    public class CreateSkillRequest : BaseRequest, IRequest<object?>
    {
        public CreateSkillRequest(Command command) : base(command)
        {
        }
    }

    public class CreateSkillRequestHandler : BaseCommandHandler, IRequestHandler<CreateSkillRequest, object?>
    {
        public CreateSkillRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(CreateSkillRequest request, CancellationToken cancellationToken)
        {
            var requestData = request?.RequestData?.ToString();
            if (request == null || requestData == null) return default;

            return new { };
        }
    }
}
