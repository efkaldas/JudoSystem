using JudoSystem.Models.Dao;
using JudoSystem.SQL.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.SQL.Interfaces
{
    public interface IJudokaSql
    {
        List<JudokaDao> GetJudokas();
        List<JudokaDao> GetUserJudokas(int userId);
        JudokaDao GetJudokaById(int id);
        void InsertJudoka(JudokaDao judoka);
        void UpdateJudoka(JudokaDao judoka);
        void DeleteJudoka(int id);

    }
}
