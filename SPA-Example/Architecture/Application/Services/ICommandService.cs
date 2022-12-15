namespace SPA_Example.Architecture.Application.Services
{
    public interface ICommandService
    {
        Task<object?> Handle(Command command);
    }
}