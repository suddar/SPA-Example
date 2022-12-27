using Domain.Commands;

namespace Application.Commands.Abstractions
{
    public abstract class BaseRequest : IRequest<object?>
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

        public TData? DeserializeObject<TData>()
        {
            var requestData = Command?.RequestData?.ToString();
            if (Command == null || requestData == null) throw new NullReferenceException();
            return JsonConvert.DeserializeObject<TData>(requestData);
        }
    }
}
