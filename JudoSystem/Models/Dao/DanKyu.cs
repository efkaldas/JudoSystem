using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Models.Dao
{
    public class DanKyu
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
    }
}
