using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_PA.Domain;

namespace WEB_PA.Models
{
    public class TaskModel
    {
        public string CurrentUser;
        public Tassk TaskData;
        public Map MapData;
        public List<Map> MapsData;
        public List<Point> PointsData;
                       
        public TaskModel(Tassk taskData, Map mapData, List<Point> pointsData, string currentUser)
        {
            TaskData = taskData;
            MapData = mapData;
            PointsData = pointsData;
            CurrentUser = currentUser;
        }

        public TaskModel(Tassk taskData, Map mapData, List<Point> pointsData, string currentUser, List<Map> mapsData)
        {
            TaskData = taskData;
            MapData = mapData;
            PointsData = pointsData;
            CurrentUser = currentUser;
            MapsData = mapsData;
        }
    }
    
}
