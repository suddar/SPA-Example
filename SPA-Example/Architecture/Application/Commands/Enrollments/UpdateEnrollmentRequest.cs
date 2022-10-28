namespace SPA_Example.Architecture.Application.Commands
{
    public class UpdateEnrollmentRequest : BaseRequest, IRequest<object?>
    {
        public UpdateEnrollmentRequest(Command command) : base(command)
        {
        }
    }

    public class UpdateEnrollmentRequestHandler : BaseCommandHandler, IRequestHandler<UpdateEnrollmentRequest, object?>
    {
        public UpdateEnrollmentRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(UpdateEnrollmentRequest request, CancellationToken cancellationToken)
        {
            var requestData = request?.RequestData?.ToString();
            if (request == null || requestData == null) return default;

            return new { };
        }
    }
}
