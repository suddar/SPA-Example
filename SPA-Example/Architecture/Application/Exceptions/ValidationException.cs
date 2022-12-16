using FluentValidation.Results;

namespace SPA_Example.Architecture.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public IDictionary<string, string[]>? Errors { get; set; }
        public ValidationException() : base("One or more validation failures have occurred.") { }

        public ValidationException(string? message) : base(message) { }

        public ValidationException(IDictionary<string, string[]>? errors) : this()
        {
            Errors = errors;
        }
    }
}
