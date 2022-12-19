namespace SPA_Example.Architecture.Application.Commands
{
    public class GetUserByIdRequest : BaseRequest
    {
        public GetUserByIdRequest(Command command) : base(command)
        {
        }
    }

    public class GetUserByIdRequesttHandler : BaseRequestHandler, IRequestHandler<CreateCourseRequest, object?>
    {
        public GetUserByIdRequesttHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(CreateCourseRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new { });
        }
    }
}
