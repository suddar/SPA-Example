namespace Application.Commands
{
    public class DeleteUserRequest : BaseRequest
    {
        public DeleteUserRequest(Command command) : base(command)
        {
        }
    }

    public class DeleteUserRequestHandler : BaseRequestHandler, IRequestHandler<CreateCourseRequest, object?>
    {
        public DeleteUserRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(CreateCourseRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new { });
        }
    }
}
