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
        IGenderRepository Gender { get; }
        IRoleRepository Role { get; }
        IUserRoleRepository UserRole { get; }
        IJudokaRepository Judoka { get; }
        IDanKyu DanKyu { get; }
        ICompetitions Competitions { get; }
        IAgeGroup AgeGroup { get; }
        ICompetitionsType CompetitionsType { get; }
        void Save();
    }
}
