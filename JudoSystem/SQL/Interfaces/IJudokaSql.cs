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
        List<JudokaDao> getJudokas();
        List<JudokaDao> getUserJudokas(int userID);
        JudokaDao getJudokaById(int id);
        void insertJudoka(JudokaDao judoka);
        void updateJudoka(JudokaDao judoka);
        void deleteJudoka(int id);

    }
}
