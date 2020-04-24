using Contracts;
using Contracts.Interfaces;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class CompetitionsTypeRepository : RepositoryBase<CompetitionsType>, ICompetitionsType
    {
        public CompetitionsTypeRepository(JudoDbContext repositoryContext)
    : base(repositoryContext)
        {
        }
    }
}
