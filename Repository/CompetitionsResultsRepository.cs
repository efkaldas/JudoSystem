using Contracts;
using Contracts.Interfaces;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class CompetitionsResultsRepository : RepositoryBase<CompetitionsResults>, ICompetitionsResults
    {
        public CompetitionsResultsRepository(JudoDbContext repositoryContext)
: base(repositoryContext)
        {
        }
    }
}
