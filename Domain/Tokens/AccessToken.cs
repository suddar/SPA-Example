﻿namespace Domain.Tokens
{
    public class AccessToken
    {
        public string? Value { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
