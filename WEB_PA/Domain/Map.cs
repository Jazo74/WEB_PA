using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_PA.Domain
{
    public class Map
    {
        public int MapId { get; set; }
        public string MapName { get; set; }
        public string MapLink { get; set; }

        public Map(string mapName, string MapLink)
        {
            MapName = mapName;
            MapLink = mapName;
        }

    }
}
