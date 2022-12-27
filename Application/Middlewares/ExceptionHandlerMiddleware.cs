using Application.Exceptions.Handlers;
using Application.Exceptions.Handlers.Abstractions;

namespace Application.Middlewares
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
