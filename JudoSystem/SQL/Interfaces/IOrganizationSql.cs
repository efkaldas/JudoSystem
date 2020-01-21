using JudoSystem.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.SQL.Interfaces
{
    public interface IOrganizationSql
    {
        List<OrganizationDao> GetOrganizations();
        OrganizationDao GetOrganization(int id);
        OrganizationDao GetOrganizationByUserId(int userId);
        int InsertOrganization(OrganizationDao newOrganization);
        void UpdateOrganization(OrganizationDao newOrganization);
        void DeleteOrganization(int id);
    }
}
