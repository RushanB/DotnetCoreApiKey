using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using DotnetCoreApiKey.Auth;

namespace DotnetCoreApiKey
{
    public static class ApiKeyAuthenticationExtensions {
        public static IApplicationBuilder UseApiKeyAuthentication(this IApplicationBuilder app) 
        {
            return UseApiKeyAuthentication(app, new ApiKeyAuthenticationOptions());
        }

        public static IApplicationBuilder UseApiKeyAuthentication(this IApplicationBuilder app, ApiKeyAuthenticationOptions options) 
        {
            if(app == null)
                throw new ArgumentNullException(nameof(app));
            if(options == null)
                throw new ArgumentNullException(nameof(options));

            return app.UseMiddleware<ApiKeyAuthenticationMiddleware>(Options.Create(options));
        }
    }
}