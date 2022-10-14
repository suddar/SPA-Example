namespace SPA_Example.Architecture.Domain.Tokens
{
    public class AccessToken
    {
        public string? Value { get; internal set; }
        public DateTime ExpirationTime { get; internal set; }
    }
}
