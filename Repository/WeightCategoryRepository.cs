using Contracts;
using Contracts.Interfaces;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class WeightCategoryRepository : RepositoryBase<WeightCategory>, IWeightCategory
    {
        public WeightCategoryRepository(JudoDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
