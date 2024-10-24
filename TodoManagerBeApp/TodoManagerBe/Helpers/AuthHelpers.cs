using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TodoManagerBe.Helpers
{
    public class AuthHelpers
    {
        public interface SystemUser
        {
            public string Id { get; set; }
            public string Username { get; set; }
        }

        public string GenerateJWTToken(SystemUser user) // generate jwt token
        {
            var claims = new List<Claim> // claims
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var jwtToken = new JwtSecurityToken( // jwt token
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddDays(30),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(
                   Encoding.UTF8.GetBytes("this_is_my_dummy_secret")
                    ),
                SecurityAlgorithms.HmacSha256Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken); // return jwt token
        }
    }
}
