using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_PA.Domain
{
    public class Event
    {
        public int EventID { get; set; }
        public int OwnerID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string LocCoord { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public string LogoLink { get; set; }
        public int OpenTopicID { get; set; }
        public int ClosedTopicID { get; set; }

        public Event(int ownerID, string name, string location, 
                    string locCoord, string descripion, DateTime time, 
                    string logoLink, int openTopicID, int closedTopicID)
        {
            OwnerID = ownerID;
            Name = name;
            Location = location;
            LocCoord = locCoord;
            Description = descripion;
            Time = time;
            LogoLink = logoLink;
            OpenTopicID = openTopicID;
            ClosedTopicID = closedTopicID;

        }
    }
}
