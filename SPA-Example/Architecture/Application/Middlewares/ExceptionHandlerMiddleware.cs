using SPA_Example.Architecture.Application.Exceptions.Handlers;

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
            catch (Exception e)
            {
                BaseExceptionHandler handler = e switch
                {
                    ValidationException => new ValidationExceptionHandler(context),
                    _ => new UnhandledExceptionHandler(context)
                };
                await handler.HandleException(e);
            }
        }
    }
}
