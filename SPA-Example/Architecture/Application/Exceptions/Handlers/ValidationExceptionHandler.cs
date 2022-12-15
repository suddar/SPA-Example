using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Net;

namespace SPA_Example.Architecture.Application.Exceptions.Handlers
{
    public class ValidationExceptionHandler : BaseExceptionHandler
    {
        public ValidationExceptionHandler(HttpContext httpContext) : base(httpContext) { }
        public async override Task HandleException(Exception exception)
        {
            var validationException = (ValidationException)exception;
            if (validationException == null)
                throw new NullReferenceException();

            var result = new
            {
                StatusCode = HttpStatusCode.BadRequest,
                validationException.Message,
                Error = validationException.Errors
            };

            await WriteResponseAsync(result);
        }
    }
}
