using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_PA.Domain
{
    public class Event
    {
        public int EventID { get; set; }
        public string OwnerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string GpsCoord { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }

        public Event(string ownerID, string name, string address, 
                    string gpsCoord, string descripion, DateTime time)
        {
            OwnerID = ownerID;
            Name = name;
            Address = address;
            GpsCoord = gpsCoord;
            Description = descripion;
            Time = time;
        }

        public Event(string ownerID, string name, string address,
                    string gpsCoord, string descripion, DateTime time, int eventId)
        {
            EventID = eventId;
            OwnerID = ownerID;
            Name = name;
            Address = address;
            GpsCoord = gpsCoord;
            Description = descripion;
            Time = time;
        }
        public Event() { }
    }
}
