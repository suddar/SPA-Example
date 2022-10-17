namespace SPA_Example.Architecture.Application.Commands
{
    public class CreateUserRequest : BaseRequest, IRequest<object?>
    {
        public CreateUserRequest(Command command) : base(command)
        {
        }
    }

    public class CreateUserRequestHandler : BaseCommandHandler, IRequestHandler<CreateUserRequest, object?>
    {
        public CreateUserRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var newUser = request.DeserializeObject<AppUser?>();
            if (newUser == null) return null;

            await dbContext.AddAsync(newUser, cancellationToken);
            return new { Message = "Success" };
        }
    }
}
