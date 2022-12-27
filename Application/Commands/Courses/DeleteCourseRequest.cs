namespace Application.Commands
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
            return await Task.FromResult(new { });
        }
    }
}
