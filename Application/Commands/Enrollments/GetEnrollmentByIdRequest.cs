namespace Application.Commands
{
    public class GetEnrollmentByIdRequest : BaseRequest
    {
        public GetEnrollmentByIdRequest(Command command) : base(command)
        {
        }
    }

    public class GetEnrollmentByIdRequestHandler : BaseRequestHandler, IRequestHandler<GetEnrollmentByIdRequest, object?>
    {
        public GetEnrollmentByIdRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(GetEnrollmentByIdRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new { });
        }
    }
}
