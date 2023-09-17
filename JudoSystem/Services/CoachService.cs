using Contracts.Interfaces;
using Entities.Models;
using JudoSystem.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace JudoSystem.Services
{
    public class CoachService : ICoachService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CoachService(IRepositoryWrapper repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<Judoka> GetUserJudokas(int userId)
        {
            var currentUserId = Convert.ToInt32(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name));
            if (userId != currentUserId)
            {
                List<User> users = _repository.User.FindByCondition(x => x.ParentUserId == currentUserId).ToList();

                if (!users.Any())
                    return null;
            }

            return _repository.Judoka.FindByConditionFull(x => x.UserId == userId).ToList();
        }

    }
}
