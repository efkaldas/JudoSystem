using Entities.Models;
using System.Collections.Generic;

namespace JudoSystem.Interfaces
{
    public interface IOrganizationService
    {
        List<Organization> Get();
        void Update(Organization organization);
    }
}
