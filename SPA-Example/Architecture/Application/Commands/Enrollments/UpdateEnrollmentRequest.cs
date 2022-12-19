namespace SPA_Example.Architecture.Application.Commands
{
    public class UpdateEnrollmentRequest : BaseRequest
    {
        public UpdateEnrollmentRequest(Command command) : base(command)
        {
        }
    }

    public class UpdateEnrollmentRequestHandler : BaseRequestHandler, IRequestHandler<UpdateEnrollmentRequest, object?>
    {
        public UpdateEnrollmentRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(UpdateEnrollmentRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new { });
        }
    }
}
