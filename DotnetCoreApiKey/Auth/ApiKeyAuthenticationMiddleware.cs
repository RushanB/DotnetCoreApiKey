using System;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace DotnetCoreApiKey.Auth
{
    public class ApiKeyAuthenticationMiddleware : AuthenticationMiddleware<ApiKeyAuthenticationOptions>
    {
        private IApiKeyValidator _validator;

        public ApiKeyAuthenticationMiddleware(
           IApiKeyValidator validator,
           RequestDelegate next,
           IOptions<ApiKeyAuthenticationOptions> options,
           ILoggerFactory loggerFactory,
           UrlEncoder encoder)
           : base(next, options, loggerFactory, encoder)
        {
            _validator = validator;
        }

        protected override AuthenticationHandler<ApiKeyAuthenticationOptions> CreateHandler()
        {
            return new ApiKeyAuthenticationHandler(_validator);
        }
    }
}
