using eventPlannerBack.BLL.Interfaces;
using eventPlannerBack.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eventPlannerBack.BLL.Service
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;

        public TokenService(UserManager<User> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<string> GenerateToken(string email, int expirationDay)
        {
           
                var user = await userManager.FindByEmailAsync(email);

                var roles = await userManager.GetRolesAsync(user);

                var claims = new List<Claim>() { new Claim("mail", email), new Claim("id", user.Id) };

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }


                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]!));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var expiration = DateTime.UtcNow.AddDays(expirationDay);

                var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiration, signingCredentials: creds);

                var tokenResponse = new JwtSecurityTokenHandler().WriteToken(token);



            return tokenResponse;
        }
    }
}
