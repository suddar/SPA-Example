using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SPA_Example.Architecture.Application.Exceptions.Handlers;

namespace SPA_Example.Architecture.Application.Exceptions
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case ValidationException e:
                    context.Result = new BadRequestObjectResult(e.Errors);
                    return;
            }
        }
    }
}
