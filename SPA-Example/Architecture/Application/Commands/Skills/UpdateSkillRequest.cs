namespace SPA_Example.Architecture.Application.Commands
{
    public class UpdateSkillRequest : BaseRequest
    {
        public UpdateSkillRequest(Command command) : base(command)
        {
        }
    }

    public class UpdateSkillRequestHandler : BaseRequestHandler, IRequestHandler<UpdateSkillRequest, object?>
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
