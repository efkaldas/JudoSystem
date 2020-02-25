using Contracts;
using Contracts.Interfaces;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class UserRoleRepository : RepositoryBase<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(JudoDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
