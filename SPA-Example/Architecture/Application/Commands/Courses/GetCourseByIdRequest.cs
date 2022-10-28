namespace SPA_Example.Architecture.Application.Commands
{
    public class GetCourseByIdRequest : BaseRequest, IRequest<object?>
    {
        public GetCourseByIdRequest(Command command) : base(command)
        {
        }
    }

    public class GetCourseByIdRequestHandler : BaseCommandHandler, IRequestHandler<GetCourseByIdRequest, object?>
    {
        public GetCourseByIdRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(GetCourseByIdRequest request, CancellationToken cancellationToken)
        {
            var requestData = request?.RequestData?.ToString();
            if (request == null || requestData == null) return default;

            return new { };
        }
    }
}
