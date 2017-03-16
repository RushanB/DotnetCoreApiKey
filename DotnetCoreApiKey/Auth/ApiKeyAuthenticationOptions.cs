using Microsoft.AspNetCore.Builder;

namespace DotnetCoreApiKey.Auth
{
    public class ApiKeyAuthenticationOptions : AuthenticationOptions
    {
        public const string Scheme = "ApiKey";
        public string HeaderName { get; set; } = "Authorization";

        public ApiKeyAuthenticationOptions()
        {
            AutomaticAuthenticate = true;
            AutomaticChallenge = true;
            AuthenticationScheme = Scheme;
        }
    }
}
