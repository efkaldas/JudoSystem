using Contracts;
using Contracts.Interfaces;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class OrganizationTypeRepository : RepositoryBase<OrganizationType>, IOrganizationTypeRepository
    {
        public OrganizationTypeRepository(JudoDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
