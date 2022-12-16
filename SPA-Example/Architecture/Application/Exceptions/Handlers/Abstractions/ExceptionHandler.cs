using Microsoft.AspNetCore.Mvc.Filters;

namespace SPA_Example.Architecture.Application.Exceptions.Handlers.Abstractions
{
    public abstract class ExceptionHandler : IExceptionHandler
    {
        public virtual Task HandleExceptionAsync(Exception exception, HttpContext httpContext) { return Task.CompletedTask; }
        public virtual void HandleException(Exception exception, HttpContext httpContext) { }
    }
}
