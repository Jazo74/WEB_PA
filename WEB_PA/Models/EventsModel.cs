using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_PA.Domain;

namespace WEB_PA.Models
{
    public class EventsModel
    {
        public List<Event> Events = new List<Event>();
        public string CurrentUser;
        public EventsModel(List<Event> events, string currentUser)
        {
            Events = events;
            CurrentUser = currentUser;
        }
    }
    
}
