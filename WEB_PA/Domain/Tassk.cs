using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_PA.Domain
{
    public class Tassk
    {
        public int TaskID { get; set; }
        public int EventID { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MapID { get; set; }

        public Tassk(int eventID, int serialNumber, string name, string description, int mapID)
        {
            EventID = eventID;
            SerialNumber = serialNumber;
            Name = name;
            Description = description;
            MapID = mapID;
        }

        public Tassk(int eventID, int serialNumber, string name, string description, int mapID, int taskID)
        {
            EventID = eventID;
            SerialNumber = serialNumber;
            Name = name;
            Description = description;
            MapID = mapID;
            TaskID = taskID;
        }
        public Tassk() { }
    }
}
