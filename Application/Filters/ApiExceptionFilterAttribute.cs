using Microsoft.AspNetCore.Mvc.Filters;
using Application.Exceptions.Handlers;
using Application.Exceptions.Handlers.Abstractions;


namespace Application.Filters
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
