namespace SPA_Example.Architecture.Domain.Identity
{
    public class JWToken
    {
        public Guid UserId { get; internal set; }
        public string Token { get; internal set; }
    }
}
