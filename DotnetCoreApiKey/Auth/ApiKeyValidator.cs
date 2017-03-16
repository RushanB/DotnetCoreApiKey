using System;
using System.Threading.Tasks;

namespace DotnetCoreApiKey.Auth
{
    public class ApiKeyValidator : IApiKeyValidator
    {
        public Task<(bool IsValid, int UserId, string UserName)> ValidateAsync(string apiKey)
        {
            if (apiKey == "1234567890")
                return Task.FromResult((true, 123, "Acme Corporation"));

            return Task.FromResult((false, 0, string.Empty));
        }
    }
}
