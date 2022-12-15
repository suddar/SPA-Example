namespace SPA_Example.Architecture.Application.Commands
{
    public class UpdateCourseRequest : BaseRequest
    {
        public UpdateCourseRequest(Command command) : base(command)
        {
        }
    }

    public class UpdateCourseRequestHandler : BaseRequestHandler, IRequestHandler<UpdateCourseRequest, object?>
    {
        public UpdateCourseRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public Task<object?> Handle(UpdateCourseRequest request, CancellationToken cancellationToken)
        {
            return default;
        }
    }
}
