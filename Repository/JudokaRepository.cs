using Contracts;
using Contracts.Interfaces;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class JudokaRepository : JudokaBase, IJudokaRepository
    {
        public JudokaRepository(JudoDbContext repositoryContext)
    : base(repositoryContext)
        {
        }
    }
}
