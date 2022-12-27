using System.Net;

namespace Domain.Results
{
    public record ExceptionResult
    {
        public string? Title { get; set; }
        public HttpStatusCode Status { get; set; }
        public string? Message { get; set; }
        public IDictionary<string, string[]>? Errors { get; set; }
    }
}
