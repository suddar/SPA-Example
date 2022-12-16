using Microsoft.AspNetCore.Mvc.Filters;
using SPA_Example.Architecture.Application.Exceptions.Handlers;
using SPA_Example.Architecture.Application.Exceptions.Handlers.Abstractions;

namespace SPA_Example.Architecture.Application.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public async override Task OnExceptionAsync(ExceptionContext context)
        {
            ExceptionHandler handler = context.Exception switch
            {
                ValidationException => new ValidationExceptionHandler(),
                _ => new UnhandledExceptionHandler()
            };
            await handler.HandleExceptionAsync(context.Exception, context.HttpContext);
            await Task.FromResult(base.OnExceptionAsync(context));
        }
    }
}
