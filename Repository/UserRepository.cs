using Contracts;
using Contracts.Interfaces;
using Entities;
using Entities.Models;
using System;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(JudoDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
