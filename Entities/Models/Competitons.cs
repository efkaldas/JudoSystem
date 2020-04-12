using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Competitons
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool CardPayment { get; set; }
        public List<AgeGroup> AgeGroups { get; set; }
    }
}
