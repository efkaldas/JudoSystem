﻿using JudoSystem.Models;
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
        public string generateToken(IConfiguration configuration, UserDao user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SigningKey"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            ClaimsIdentity identity = getClaimsIdentity(user);

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
        private ClaimsIdentity getClaimsIdentity(UserDao user)
        {
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token");

            if (user.UserRole == 1)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, UserDao.ADMIN));
                return claimsIdentity;
            }
            if (user.UserRole == 2)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, UserDao.USER));
                return claimsIdentity;
            }
            return claimsIdentity;
        }
    }
}
