using eBook_BE.ConfigSettings;
using eBook_BE.Helpers.Interface;
using eBook_BE.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eBook_BE.Helpers
{
    public class TokenService : ITokenService
    {
        private readonly JWTConfigSetting _jWTConfigSetting;
        public TokenService(JWTConfigSetting jWTConfigSetting)
        {
            _jWTConfigSetting = jWTConfigSetting;
        }
        public string GenerateAccessToken(UserApplication user, IEnumerable<string> roles)
        {
            var key = Encoding.ASCII.GetBytes(_jWTConfigSetting.SecretKey);

            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            };
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            // Thêm các claim cho từng role của user
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jWTConfigSetting?.Issuer,
                Audience = _jWTConfigSetting?.Audience,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(_jWTConfigSetting.TokenValidityInDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
