namespace SPA_Example.Architecture.Application.Commands
{
    public class DeleteCourseRequest : BaseRequest
    {
        public DeleteCourseRequest(Command command) : base(command)
        {
        }
    }

    public class DeleteCourseRequestHandler : BaseRequestHandler, IRequestHandler<DeleteCourseRequest, object?>
    {
        public DeleteCourseRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(DeleteCourseRequest request, CancellationToken cancellationToken)
        {
            var requestData = request?.RequestData?.ToString();
            if (request == null || requestData == null) return default;

            return default;
        }
    }
}
