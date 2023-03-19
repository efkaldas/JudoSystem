using Entities.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace JudoSystem.Interfaces
{
    public interface IOrganizationService
    {
        List<Organization> Get();
        void Update(Organization organization);
        Organization UpdateImage(int userId, IFormFile image);
    }
}
