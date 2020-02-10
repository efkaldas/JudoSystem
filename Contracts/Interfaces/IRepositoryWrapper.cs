using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IOrganizationRepository Organization { get; }
        IOrganizationTypeRepository OrganizationType { get; }
        void Save();
    }
}
