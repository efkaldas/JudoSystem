using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JudoSystem.Models.Dao
{
    public class EventDao
    {
        public int Id { get; set; }
        public int EventType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal EntryFee { get; set; }
        public string RegistrationStartDate { get; set; }
        public string RegistrationEndDate { get; set; }
        public string EventStartDate { get; set; }
        public List<AgeGroupDao> AgeGroups { get; set; }

    }

}
