using Contracts;
using Contracts.Interfaces;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class GenderRepository : RepositoryBase<Gender>, IGenderRepository
    {
        public GenderRepository(JudoDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}

