namespace SPA_Example.Architecture.Application.Commands
{
    public class UpdateSkillRequest : BaseRequest, IRequest<object?>
    {
        public UpdateSkillRequest(Command command) : base(command)
        {
        }
    }

    public class UpdateSkillRequestHandler : BaseCommandHandler, IRequestHandler<UpdateSkillRequest, object?>
    {
        public UpdateSkillRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(UpdateSkillRequest request, CancellationToken cancellationToken)
        {
            var requestData = request?.RequestData?.ToString();
            if (request == null || requestData == null) return default;

            return new { };
        }
    }
}
