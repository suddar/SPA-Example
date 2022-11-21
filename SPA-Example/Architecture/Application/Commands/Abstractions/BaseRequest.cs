using MediatR;

namespace Fullstack_Example.Architecture.Application.Commands.Abstractions
{
    public abstract class BaseRequest: IRequest<object?>
    {
        public Command Command { get; set; }
        public BaseRequest(Command command)
        {
            Command = command;
        }

        public object? RequestData
        {
            get => Command.RequestData;
        }

        public T? DeserializeObject<T>()
        {
            var requestData = Command?.RequestData?.ToString();
            if (Command == null || requestData == null) return default;
            return JsonConvert.DeserializeObject<T>(requestData);
        }
    }
}
