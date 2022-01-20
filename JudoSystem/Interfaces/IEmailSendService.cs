using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Interfaces
{
    public interface IEmailSendService
    {
        public void SendEmail(string title, string message, List<string> recipients, string fileToAttach = null);
        public string GetAdminEmail();
    }
}
