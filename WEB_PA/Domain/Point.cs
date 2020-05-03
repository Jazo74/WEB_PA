using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WEB_PA.Domain
{
    public class Point
    {
        public int PointID { get; set; }
        public int TaskID { get; set; }
        public int CoordX  { get; set; }
        public int CoordY { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Mark { get; set; }
        public bool RightPoint { get; set; }

        public Point(int taskID, int coordX, int coordY, string name, string description, string mark, bool rightPoint)
        {
            TaskID = taskID;
            CoordX = coordX;
            CoordY = coordY;
            Name = name;
            Description = description;
            Mark = mark;
            RightPoint = rightPoint;

        }
    }
}
