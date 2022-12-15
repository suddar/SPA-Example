namespace SPA_Example.Architecture.Application.Exceptions.Handlers
{
    public class UnhandledExceptionHandler : BaseExceptionHandler
    {
        public UnhandledExceptionHandler(HttpContext httpContext) : base(httpContext)
        {
        }

        public override async Task HandleException(Exception exception)
        {
            await WriteResponseAsync(exception);
        }
    }
}
