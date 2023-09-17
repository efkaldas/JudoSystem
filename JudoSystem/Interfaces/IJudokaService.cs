using Entities.Models;
using System.Collections.Generic;

namespace JudoSystem.Interfaces
{
    public interface IJudokaService
    {
        List<Judoka> GetUserJudokas();
    }
}
