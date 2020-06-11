using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WEB_PA.Domain
{
    public class Point
    {
        public int PointID { get; set; }
        public int TaskID { get; set; }
        public float CoordX  { get; set; }
        public float CoordY { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool RightPoint { get; set; }

        public Point(int taskID, float coordX, float coordY, string name, string description, int pointID)
        {
            TaskID = taskID;
            CoordX = coordX;
            CoordY = coordY;
            Name = name;
            Description = description;
            PointID = pointID;
        }

        public Point(int taskID, float coordX, float coordY, string name, string description)
        {
            TaskID = taskID;
            CoordX = coordX;
            CoordY = coordY;
            Name = name;
            Description = description;
        }

    }
}
