using Contracts;
using Contracts.Interfaces;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class AgeGroupRepository : RepositoryBase<AgeGroup>, IAgeGroup
    {
        public AgeGroupRepository(JudoDbContext repositoryContext)
    : base(repositoryContext)
        {
        }
    }
}
