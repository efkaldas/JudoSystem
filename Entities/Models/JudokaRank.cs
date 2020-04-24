using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class JudokaRank
    {
        [Key]
        public int Id { get; set; }
        public int JudokaId { get; set; }
        public Judoka Judoka { get; set; }
        public int Points { get; set; }
    }
}
