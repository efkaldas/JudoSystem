using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Models
{
    public class JwtToken
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string jwtToken { get; set; }
        public DateTime tokenExpDate { get; set; }
    }
}
