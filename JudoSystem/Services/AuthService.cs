using Entities.Models;
using JudoSystem.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JudoSystem.Services
{
    public class AuthService
    {
        public string GenerateToken(IConfiguration configuration, User user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SigningKey"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            ClaimsIdentity identity = GetClaimsIdentity(user);

            var tokeOptions = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                claims: identity.Claims,
                expires: DateTime.Now.AddDays(Convert.ToInt32(configuration["JWT:ExpireTime"])),
                signingCredentials: signinCredentials
            );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return tokenString;
        }
        private ClaimsIdentity GetClaimsIdentity(User user)
        {
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token");

            foreach (UserRole role in user.UserRoles)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.Role.RoleNameEN));
            }

            return claimsIdentity;
        }
    }
}
