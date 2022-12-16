using SPA_Example.Architecture.Application.Exceptions.Handlers;
using SPA_Example.Architecture.Application.Exceptions.Handlers.Abstractions;

namespace SPA_Example.Architecture.Application.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                IExceptionHandler handler = exception switch
                {
                    ValidationException => new ValidationExceptionHandler(),
                    _ => new UnhandledExceptionHandler()
                };
                await handler.HandleExceptionAsync(exception, context);
            }
        }
    }
}
