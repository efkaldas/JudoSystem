using Entities.Models;
using System.Collections.Generic;

namespace JudoSystem.Interfaces
{
    public interface ICoachService
    {
        List<Judoka> GetUserJudokas(int userId);
    }
}
