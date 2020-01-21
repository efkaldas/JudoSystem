using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Models.Dao
{
    public class CategoryDao
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GroupID { get; set; }
        public List<CompetitorDao> Competitors { get; set; }
    }
}
