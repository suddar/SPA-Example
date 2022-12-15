using SPA_Example.Architecture.Application.Commands;
using System.ComponentModel;

namespace SPA_Example.Architecture.Application.Services
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
            return null;
        }

        public BaseRequest? CreateCommand(Command command)
        {
            var type = Type.GetType(string.Format("SPA_Example.Architecture.Application.Commands.{0}", command.Name + "Request"));
            if (type != null)
                return (BaseRequest?)Activator.CreateInstance(type, new object[] { command });
            return null;
        }
    }
}
