using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Models.Dao
{
    public class AgeGroupDao
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Gender { get; set; }
        public int YearsFrom { get; set; }
        public int YearsTo { get; set; }
        public int EventID { get; set; }
        public List<CategoryDao> Categories { get; set; }
    }
}
