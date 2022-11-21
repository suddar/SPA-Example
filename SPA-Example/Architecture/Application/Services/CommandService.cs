using SPA_Example.Architecture.Application.Commands;

namespace SPA_Example.Architecture.Application.Services
{
    public class CommandService : ICommandService
    {
        private readonly IMediator _mediator;
        public CommandService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public object? Handle(Command command)
        {
            var request = CreateCommand(command);
            if (request == null) return null;

            var response = _mediator.Send(request);
            if (response == null) return null;

            return response.Result;
        }

        public BaseRequest? CreateCommand(Command command)
        {
            var type = Type.GetType(string.Format("SPA_Example.Architecture.Application.Commands.{0}", command.Name + "Request"));
            if (type == null) return null;
            return (BaseRequest?)Activator.CreateInstance(type, new object[] { command });
        }
    }
}
