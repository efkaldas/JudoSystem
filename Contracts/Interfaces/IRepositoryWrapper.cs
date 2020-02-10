using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Interfaces
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IOrganizationTypeRepository OrganizationType { get; }
        void Save();
    }
}
