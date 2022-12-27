namespace Application.Commands
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
            return await Task.FromResult(new { });
        }
    }
}
