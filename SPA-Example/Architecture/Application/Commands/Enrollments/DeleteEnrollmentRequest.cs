namespace SPA_Example.Architecture.Application.Commands
{
    public class DeleteEnrollmentRequest : BaseRequest
    {
        public DeleteEnrollmentRequest(Command command) : base(command)
        {
        }
    }

    public class DeleteEnrollmentRequestHandler : BaseRequestHandler, IRequestHandler<DeleteEnrollmentRequest, object?>
    {
        public DeleteEnrollmentRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(DeleteEnrollmentRequest request, CancellationToken cancellationToken)
        {
            var requestData = request?.RequestData?.ToString();
            if (request == null || requestData == null) return default;

            return new { };
        }
    }
}
