using Contracts.Interfaces;
using Entities.Models;
using JudoSystem.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace JudoSystem.Services
{
    public class JudokaService : IJudokaService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public JudokaService(IRepositoryWrapper repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<Judoka> GetUserJudokas()
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);
            List<Judoka> judokas = _repository.Judoka.FindByConditionFull(x => x.UserId == Convert.ToInt32(userId)).ToList();
            return judokas;
        }
    }
}
