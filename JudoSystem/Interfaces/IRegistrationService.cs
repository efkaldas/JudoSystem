using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Interfaces
{
    public interface IRegistrationService
    {
        public void SendMessage(User user);
    }
}
