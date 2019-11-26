using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Models.Dao
{
    public class AgeGroupDao
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public string Gender { get; set; }
        public string YearsFrom { get; set; }
        public string YearsTo { get; set; }
        public int EventID { get; set; }
        public List<CategoryDao> Categories { get; set; }
    }
}
