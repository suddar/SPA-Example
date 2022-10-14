﻿namespace SPA_Example.Architecture.Domain.Tokens
{
    public class JWTConfiguration
    {
        public string? AccessTokenSecret { get; set; }
        public double AccessTokenExpirationMinutes { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? RefreshTokenSecret { get; set; }
        public double RefreshTokenExpirationMinutes { get; set; }
    }
}