using eBook_BE.Helpers.Interface;
using System.Security.Claims;

namespace eBook_BE.Helpers
{
    public class ClaimService : IClaimService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimService(IHttpContextAccessor httpContextAccessor) => this._httpContextAccessor = httpContextAccessor;

        public string GetUserId() => this.GetClaim(ClaimTypes.NameIdentifier);

        public string GetUserName() => this.GetClaim(ClaimTypes.Name);
        private string GetClaim(string key) => this._httpContextAccessor.HttpContext?.User?.FindFirst(key)?.Value ?? string.Empty;
    }
}
