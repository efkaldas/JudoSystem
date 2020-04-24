using Contracts;
using Contracts.Interfaces;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class CompetitionsRepository : RepositoryBase<Competitions>, ICompetitions
    {
        public CompetitionsRepository(JudoDbContext repositoryContext)
    : base(repositoryContext)
        {
        }
    }
}
