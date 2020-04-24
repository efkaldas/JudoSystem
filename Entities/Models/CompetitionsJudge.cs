using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class CompetitionsJudge
    {
        [Key]
        public int UserId { get; set; }
        public User Judge { get; set; }
        public int CompetitionsId { get; set; }
        public Competitions Competitions { get; set; }
    }
}
