using IdentityModel.Client;

namespace InternalMVC.Services;

public interface ITokenService
{
    Task<TokenResponse> GetToken(string scope);
}