using ValidationException = SPA_Example.Architecture.Application.Exceptions.ValidationException;
namespace SPA_Example.Architecture.Application.Commands
{
    public class CreateTopicRequest : BaseRequest
    {
        public CreateTopicRequest(Command command) : base(command)
        {
        }
    }

    public class CreateTopicRequestHandler : BaseRequestHandler, IRequestHandler<CreateTopicRequest, object?>
    {
        public CreateTopicRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(CreateTopicRequest request, CancellationToken cancellationToken)
        {
            var result = Validate<Topic>(request);

            if (result == null)
                throw new NullReferenceException();

            if (!result.IsValid)
                throw new ValidationException(result.ToDictionary());

            var requestData = request?.RequestData?.ToString();
            if (request == null || requestData == null) return default;

            return await Task.FromResult(new { Message = "OK" });

        }
    }
}
