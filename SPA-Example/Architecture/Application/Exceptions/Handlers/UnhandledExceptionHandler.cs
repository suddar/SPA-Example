using Microsoft.AspNetCore.Mvc.Filters;
using SPA_Example.Architecture.Application.Exceptions.Handlers.Abstractions;

namespace SPA_Example.Architecture.Application.Exceptions.Handlers
{
    public class UnhandledExceptionHandler : ExceptionHandler
    {
        public override async Task HandleExceptionAsync(Exception exception, HttpContext httpContext)
        {
            await httpContext.Response.WriteAsJsonAsync(exception);
        }
    }
}
