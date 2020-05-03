using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_PA.Domain
{
    public class Task
    {
        public int TaskID { get; set; }
        public int CompetitionID { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MapID { get; set; }

        public Task(int competitionID, int serialNumber, string name, string description, int mapID)
        {
            CompetitionID = competitionID;
            SerialNumber = serialNumber;
            Name = name;
            Description = description;
            MapID = mapID;
        }
    }
}
