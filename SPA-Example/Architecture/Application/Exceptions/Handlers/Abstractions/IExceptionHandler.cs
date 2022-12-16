namespace SPA_Example.Architecture.Application.Exceptions.Handlers.Abstractions
{
    public interface IExceptionHandler
    {
        void HandleException(Exception exception, HttpContext httpContext);
        Task HandleExceptionAsync(Exception exception, HttpContext httpContext);
    }
}