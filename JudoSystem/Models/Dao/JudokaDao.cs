using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Models.Dao
{
    public class JudokaDao
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public int DanKyu { get; set; }
        public int BirthYears { get; set; }
        public int UserId { get; set; }
    }
}
