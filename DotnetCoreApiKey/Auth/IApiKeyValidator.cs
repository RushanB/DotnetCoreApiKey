using System;
using System.Threading.Tasks;

namespace DotnetCoreApiKey.Auth
{
    public interface IApiKeyValidator
    {
        Task<(bool IsValid, int UserId, string UserName)> ValidateAsync(string apiKey);
    }
}
