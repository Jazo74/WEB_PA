using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_PA.Domain;

namespace WEB_PA.Models
{
    public class TasksModel
    {
        public List<Tassk> Tasks = new List<Tassk>();
        public string CurrentUser;
        public TasksModel(List<Tassk> tasks, string currentUser)
        {
            Tasks = tasks;
            CurrentUser = currentUser;
        }
    }
    
}
