namespace SPA_Example.Architecture.Application.Commands
{
    public class GetCourseByIdRequest : BaseRequest
    {
        public GetCourseByIdRequest(Command command) : base(command)
        {
        }
    }

    public class GetCourseByIdRequestHandler : BaseRequestHandler, IRequestHandler<GetCourseByIdRequest, object?>
    {
        public GetCourseByIdRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public Task<object?> Handle(GetCourseByIdRequest request, CancellationToken cancellationToken)
        {
            return default;
        }
    }
}
