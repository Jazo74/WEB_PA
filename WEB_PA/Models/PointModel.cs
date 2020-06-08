using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_PA.Domain;

namespace WEB_PA.Models
{
    public class PointModel
    {
        public string CurrentUser;
        public int TaskId;
        public string PointName;
        public string PointDescription;
        public string MapLink;
                       
        public PointModel(int taskId, string pointName, string pointDescription, string currentUser, string mapLink)
        {
            TaskId = taskId;
            MapLink = mapLink;
            PointName = pointName;
            PointDescription = pointDescription;
            CurrentUser = currentUser;
        }
    }
    
}
