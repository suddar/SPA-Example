using Microsoft.AspNetCore.Mvc.Filters;

namespace SPA_Example.Architecture.Application.Services
{
    public class ExceptionService
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
        public ExceptionService()
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {

            };
        }


    }
}
