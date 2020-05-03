using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_PA.Domain
{
    public class Competition
    {
        public int CompetitionID { get; set; }
        public int EventID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        
        public Competition(int eventID, string name, string category)
        {
            EventID = eventID;
            Name = name;
            Category = category;
        }
    }
}
