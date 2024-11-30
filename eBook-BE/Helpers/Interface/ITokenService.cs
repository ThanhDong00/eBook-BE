using eBook_BE.Models;

namespace eBook_BE.Helpers.Interface
{
    public interface ITokenService
    {
        string GenerateAccessToken(UserApplication user, IEnumerable<string> roles);
    }
}
