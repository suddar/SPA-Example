namespace SPA_Example.Architecture.Application.Commands
{
    public class GetSkillByIdRequest : BaseRequest, IRequest<object?>
    {
        public GetSkillByIdRequest(Command command) : base(command)
        {
        }
    }

    public class GetSkillByIdRequestHandler : BaseCommandHandler, IRequestHandler<GetSkillByIdRequest, object?>
    {
        public GetSkillByIdRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(GetSkillByIdRequest request, CancellationToken cancellationToken)
        {
            var requestData = request?.RequestData?.ToString();
            if (request == null || requestData == null) return default;

            return new { };
        }
    }
}
