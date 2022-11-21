namespace SPA_Example.Architecture.Application.Commands
{
    public class CreateEnrollmentRequest : BaseRequest
    {
        public CreateEnrollmentRequest(Command command) : base(command)
        {
        }
    }

    public class CreateEnrollmentRequestHandler : BaseRequestHandler, IRequestHandler<CreateEnrollmentRequest, object?>
    {
        public CreateEnrollmentRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(CreateEnrollmentRequest request, CancellationToken cancellationToken)
        {
            var requestData = request?.RequestData?.ToString();
            if (request == null || requestData == null) return default;

            return new { };
        }
    }
}
