using Microsoft.AspNetCore.Http;

namespace Application.Exceptions.Handlers.Abstractions
{
    public abstract class ExceptionHandler : IExceptionHandler
    {
        public virtual Task HandleExceptionAsync(Exception exception, Microsoft.AspNetCore.Http.HttpContext httpContext) { return Task.CompletedTask; }
        public virtual void HandleException(Exception exception, HttpContext httpContext) { }
    }
}
