using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Primitives;

namespace DotnetCoreApiKey.Auth
{
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
    {
        private readonly IApiKeyValidator _validator;
        public ApiKeyAuthenticationHandler(IApiKeyValidator validator)
        {
            _validator = validator;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // Get the "Authorization" header
            if (!Context.Request.Headers.TryGetValue(Options.HeaderName, out StringValues headerValue))
            {
                return AuthenticateResult.Fail("Invalid authorization header.");
            }

            // Validate API Key
            var apiKey = headerValue[0];
            var validationResult = await _validator.ValidateAsync(apiKey);
            if (!validationResult.IsValid)
            {
                return AuthenticateResult.Fail("Invalid API key.");
            }

            // API Key is all good, set the identity
            var identity = new ClaimsIdentity(Options.AuthenticationScheme);
            identity.AddClaims(new[]
            {
                new Claim("UserId", validationResult.UserId.ToString()),
                new Claim("UserName", validationResult.UserName)
            });
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), null, Options.AuthenticationScheme);
            return AuthenticateResult.Success(ticket);
        }
    }
}
