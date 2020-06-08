using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_PA.Domain
{
    public interface IDBService
    {
        string GetNickname(string email);
        Event GetEvent(int eventId);
        List<Event> GetEventsByUser(string userId);
        void AddEvent(string ownerID, string name, string address, string gpsCoord, string descripion, DateTime time);

        void AddMap(string mapLink, string mapName, int eventId);
        Map getMap(int mapId);
        Map getMapByTaskId(int taskId);
        List<Map> GetMapsByEventId(int eventId);
        int getLastMapId(int eventId);

        Tassk GetTask(int taskId);
        List<Tassk> GetTasksByEvent(int eventId);
        void AddTask(int eventID, int serialNumber, string name, string description, int mapID);

        List<Point> GetPointsByTaskId(int taskId);
        void AddPoint(int taskId, float coordX, float coordY, string pointName, string pointDescription);
    }
}
