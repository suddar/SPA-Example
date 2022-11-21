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

        public async Task<object?> Handle(UpdateCourseRequest request, CancellationToken cancellationToken)
        {
            var requestData = request?.RequestData?.ToString();
            if (request == null || requestData == null) return default;

            return new { };
        }
    }
}
