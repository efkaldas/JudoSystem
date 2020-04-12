using Contracts;
using Contracts.Interfaces;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class DanKyuRepository : RepositoryBase<DanKyu>, IDanKyu
    {
        public DanKyuRepository(JudoDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
