namespace SPA_Example.Architecture.Application.Commands
{
    public class DeleteUserRequest : BaseRequest, IRequest<object?>
    {
        public DeleteUserRequest(Command command) : base(command)
        {
        }
    }

    public class DeleteUserRequestHandler : BaseCommandHandler, IRequestHandler<CreateCourseRequest, object?>
    {
        public DeleteUserRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(CreateCourseRequest request, CancellationToken cancellationToken)
        {
            var requestData = request?.RequestData?.ToString();
            if (request == null || requestData == null) return default;

            return new { };
        }
    }
}
