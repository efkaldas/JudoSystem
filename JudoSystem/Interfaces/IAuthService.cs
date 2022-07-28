using Entities.Models;
using Entities.Models.Dto;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(IConfiguration configuration, User user);
        void ForgotPassword(ForgotPasswordRequest model);
    }
}
