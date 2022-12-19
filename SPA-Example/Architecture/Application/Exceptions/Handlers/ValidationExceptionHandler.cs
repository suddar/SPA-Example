using System.Net;
using SPA_Example.Architecture.Application.Exceptions.Handlers.Abstractions;

namespace SPA_Example.Architecture.Application.Exceptions.Handlers
{
    public class ValidationExceptionHandler : ExceptionHandler
    {
        public override async Task HandleExceptionAsync(Exception exception, HttpContext httpContext)
        {
            var validationException = (ValidationException)exception;
            if (validationException == null)
                throw new NullReferenceException();

            var res = new ExceptionResult
            {
                Title = nameof(HttpStatusCode.BadRequest),
                Message = validationException.Message,
                Status = HttpStatusCode.BadRequest,
                Errors = validationException.Errors
            };

            await httpContext.Response.WriteAsJsonAsync(res);
        }
    }
}
