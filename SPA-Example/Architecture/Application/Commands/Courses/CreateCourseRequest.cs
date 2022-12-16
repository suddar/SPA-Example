namespace SPA_Example.Architecture.Application.Commands
{
    public class CreateCourseRequest : BaseRequest
    {
        public CreateCourseRequest(Command command) : base(command)
        {
        }
    }

    public class CreateCourseRequestHandler : BaseRequestHandler, IRequestHandler<CreateCourseRequest, object?>
    {
        public CreateCourseRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(CreateCourseRequest request, CancellationToken cancellationToken)
        {
            var validateResult = Validate<Course>(request);
            if (validateResult != null && validateResult.IsValid)
            {
                Console.Write(validateResult);
                return validateResult;
            }

            return new { };
        }
    }
}
