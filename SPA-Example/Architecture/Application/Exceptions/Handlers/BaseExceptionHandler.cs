namespace SPA_Example.Architecture.Application.Exceptions.Handlers
{
    public abstract class BaseExceptionHandler
    {
        protected HttpContext HttpContext { get; set; }
        public BaseExceptionHandler(HttpContext httpContext)
        {
            HttpContext = httpContext;
            HttpContext.Response.ContentType = "application/json";
        }

        public abstract Task HandleException(Exception exception);

        protected async Task WriteResponseAsync(object result)
        {
            await HttpContext.Response.WriteAsJsonAsync(result);
        }
    }
}
