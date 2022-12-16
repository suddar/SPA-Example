using Microsoft.AspNetCore.Components.Web;
using System.Net;

namespace SPA_Example.Architecture.Domain.Results
{
    public record CustomResult
    {
        public string? Title { get; set; }
        public HttpStatusCode Status { get; set; }
        public string? Message { get; internal set; }
        public IDictionary<string, string[]>? Errors { get; set; }
    }
}
