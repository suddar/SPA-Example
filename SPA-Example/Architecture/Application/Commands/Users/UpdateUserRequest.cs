namespace SPA_Example.Architecture.Application.Commands
{
    public class UpdateUserRequest : BaseRequest
    {
        public UpdateUserRequest(Command command) : base(command)
        {
        }
    }

    public class UpdateUserRequestHandler : BaseRequestHandler, IRequestHandler<CreateCourseRequest, object?>
    {
        public UpdateUserRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
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
