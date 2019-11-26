using JudoSystem.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.SQL.Interfaces
{
    public interface IAgeGroupSql
    {
        List<AgeGroupDao> getAgeGroups();
        AgeGroupDao getAgeGroupById(int id);
        void insertAgeGroup(AgeGroupDao newAgeGroup);
        void updateAgeGroup(AgeGroupDao newAgeGroup);
        void deleteAgeGroup(int id);
    }
}
