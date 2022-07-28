using Contracts.Interfaces;
using Entities.Models;
using Entities.Models.Dto;
using JudoSystem.Interfaces;
using JudoSystem.Models;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JudoSystem.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepositoryWrapper _db;
        private readonly IEmailSendService _emailSendService;
        public AuthService(IRepositoryWrapper db, IEmailSendService emailSendService)
        {
            _db = db;
            _emailSendService = emailSendService;
        }
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

        public void ForgotPassword(ForgotPasswordRequest forgotPasssword)
        {
            var user = _db.User.FindByCondition(x => x.Email == forgotPasssword.Email).FirstOrDefault();

            // always return ok response to prevent email enumeration
            if (user == null) return;

            // create reset token that expires after 1 day
            user.ResetToken = randomTokenString();
            user.ResetTokenExpires = DateTime.UtcNow.AddDays(1);

            _db.User.Update(user);
            _db.Save();


            var param = new Dictionary<string, string>
            {
                {"token", user.ResetToken },
                {"email", forgotPasssword.Email }
            };

            var callback = QueryHelpers.AddQueryString(forgotPasssword.ClientURI, param);

            // send email
            _emailSendService.SendEmail("Password reset", callback, new List<string> { user.Email });
        }
        private ClaimsIdentity GetClaimsIdentity(User user)
        {
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Actor, user.Status.StatusNameEN)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token");

            foreach (UserRole role in user.UserRoles)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.Role.RoleNameEN));
            }

            return claimsIdentity;
        }


        private string randomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
    }
}
