using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_PA.Domain
{
    public class Map
    {
        public int MapId { get; set; }
        public string MapLink { get; set; }
        public string MapName { get; set; }
        public int EventId { get; set; }

        public Map(string mapLink, int eventId, string mapName)
        {
            MapLink = mapLink;
            MapName = mapName;
            EventId = EventId;
        }

        public Map(string mapLink, int eventId, string mapName, int mapId)
        {
            MapLink = mapLink;
            MapName = mapName;
            EventId = eventId;
            MapId = mapId;
        }
        public Map() { }
    }
}
