using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_PA.Domain;

namespace WEB_PA.Models
{
    public class EventModel
    {
        public string CurrentUser;
        public Event EventData;
        public List<Tassk> Tasks;
        public List<Map> Maps;

        public EventModel(Event eventData, List<Tassk> tasks, List<Map> maps, string currentUser)
        {
            EventData = eventData;
            Tasks = tasks;
            Maps = maps;
            CurrentUser = currentUser;
        }
    }
    
}
