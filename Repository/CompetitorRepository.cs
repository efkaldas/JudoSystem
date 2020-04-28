using Contracts;
using Contracts.Interfaces;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class CompetitorRepository : RepositoryBase<Competitor>, ICompetitorRepository
    {
        public CompetitorRepository(JudoDbContext repositoryContext)
         : base(repositoryContext)
        {
        }
    }
}
