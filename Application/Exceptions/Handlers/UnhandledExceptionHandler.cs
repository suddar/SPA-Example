using Microsoft.AspNetCore.Mvc.Filters;
using Application.Exceptions.Handlers.Abstractions;

namespace Application.Exceptions.Handlers
{
    public class UnhandledExceptionHandler : ExceptionHandler
    {
        public override async Task HandleExceptionAsync(Exception exception, HttpContext httpContext)
        {
            await httpContext.Response.WriteAsJsonAsync(new {
                exception.Message,
                exception.InnerException,
                exception.StackTrace,
                exception.Source,
            });
        }
    }
}
