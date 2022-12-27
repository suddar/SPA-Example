using System.ComponentModel;

namespace Application.Services
{
    public class CommandService : ICommandService
    {
        private readonly IMediator _mediator;
        public CommandService(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Description("Handle command")]
        public async Task<object?> Handle(Command command)
        {
            var request = CreateCommand(command);
            if (request != null)
            {
                var response = await _mediator.Send(request);
                if (response != null)
                    return response;
            }
            throw new ValidationException();
        }

        public BaseRequest? CreateCommand(Command command)
        {
            var type = Type.GetType(string.Format("Application.Commands.{0}", command.Name + "Request"));
            if (type != null)
                return (BaseRequest?)Activator.CreateInstance(type, new object[] { command });
            throw new ValidationException();
        }
    }
}
