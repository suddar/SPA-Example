﻿using Application.Mappings.Users;
using Domain.Tokens;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Application.Services.Tokens
{
    /// <summary>
    /// AccessToken generator
    /// </summary>
    public class AccessTokenService
    {
        private readonly JWTConfiguration _configuration;
        private readonly TokenService _tokenService;
        public AccessTokenService(TokenService tokenService, IOptions<JWTConfiguration> configuration)
        {
            _tokenService = tokenService;
            _configuration = configuration.Value;
        }

        public AccessToken? GenerateToken(UserLoginDto user)
        {
            if (_configuration.AccessTokenSecret is null || _configuration.Issuer is null || _configuration.Audience is null) return default;

            List<Claim> claims = new()
            {
                new Claim("id", user.Id.ToString()),
                new Claim("Email", user.Email),
                new Claim("UserName", user.UserName),
            };

            DateTime expirationTime = DateTime.UtcNow.AddMinutes(_configuration.AccessTokenExpirationMinutes);

            var value = _tokenService.GenerateToken(
                _configuration.AccessTokenSecret,
                _configuration.Issuer,
                _configuration.Audience,
                expirationTime,
                claims);

            return new AccessToken
            {
                Value = value,
                ExpirationTime = expirationTime
            };
        }

        public bool Validate(string token)
        {
            if (token is null || _configuration.AccessTokenSecret is null)
                throw new ArgumentNullException(nameof(token));

            var tokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.AccessTokenSecret)),
                ValidIssuer = _configuration.Issuer,
                ValidAudience = _configuration.Audience,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ClockSkew = TimeSpan.Zero
            };
            return TokenService.Validate(token, tokenValidationParameters);
        }
    }
}