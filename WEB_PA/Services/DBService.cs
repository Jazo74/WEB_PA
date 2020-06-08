using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WEB_PA.Domain
{
    public class DBService : IDBService
    {
        public List<Event> GetEventsByUser(string userId)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                List<Event> events = new List<Event>();
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM events " +
                    "WHERE owner_id = @email", conn))
                {
                    cmd.Parameters.AddWithValue("email", userId);
                    var reader = cmd.ExecuteReader();
                    DateTime date = new DateTime();
                    while (reader.Read())
                    {
                        int eventId = (int)reader["event_id"];
                        string eventName = reader["event_name"].ToString();
                        string description = reader["description"].ToString();
                        string ownerEmail = reader["owner_id"].ToString();
                        string gpsCoord = reader["gps_coord"].ToString();
                        string address = reader["address"].ToString();
                        date = (DateTime)reader["event_time"];
                        events.Add(new Event(ownerEmail, eventName, address, gpsCoord, description, date, eventId));
                    }
                    return events;
                }
            }
        }

        public void AddEvent(string ownerID, string name, string address, string gpsCoord, string description, DateTime time) 
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(
                 "INSERT INTO events (owner_id, event_name, description, address, gps_coord, event_time) " +
                 "VALUES (@userId, @eventName, @description, @address, @gpsCoord, @date)", conn))
                {
                    cmd.Parameters.AddWithValue("userId", ownerID);
                    cmd.Parameters.AddWithValue("eventName", name);
                    cmd.Parameters.AddWithValue("description", description);
                    cmd.Parameters.AddWithValue("address", address);
                    cmd.Parameters.AddWithValue("gpsCoord", gpsCoord);
                    cmd.Parameters.AddWithValue("date", time);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public string GetNickname(string email)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                var userId = "";
                if (email == null)
                {
                    email = "";
                }
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT nickname FROM users " +
                    "WHERE user_id = @email", conn))
                {
                    cmd.Parameters.AddWithValue("email", email);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        userId = reader["nickname"].ToString();
                    }

                    return userId;
                }
            }
        }

        public Event GetEvent(int eventId)
        {
            Event eventData = new Event();
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM events " +
                    "WHERE event_id = @eventId", conn))
                {
                    cmd.Parameters.AddWithValue("eventId", eventId);
                    var reader = cmd.ExecuteReader();
                    DateTime date = new DateTime();
                    while (reader.Read())
                    {
                        int eventID = (int)reader["event_id"];
                        string eventName = reader["event_name"].ToString();
                        string description = reader["description"].ToString();
                        string ownerEmail = reader["owner_id"].ToString();
                        string gpsCoord = reader["gps_coord"].ToString();
                        string address = reader["address"].ToString();
                        date = (DateTime)reader["event_time"];
                        eventData = new Event(ownerEmail, eventName, address, gpsCoord, description, date, eventID);
                    }
                }
            }
            return eventData;
        }

        public Tassk GetTask(int taskId)
        {
            Tassk task = new Tassk();
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM tasks " +
                    "WHERE task_id = @taskId ORDER BY serial_number ASC", conn))
                {
                    cmd.Parameters.AddWithValue("taskId", taskId);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int taskID = (int)reader["task_id"];
                        int eventID = (int)reader["event_id"];
                        string taskName = reader["task_name"].ToString();
                        string description = reader["task_description"].ToString();
                        int serialNumber = (int)reader["serial_number"];
                        int mapId = (int)reader["map_id"];
                        task = new Tassk(eventID, serialNumber, taskName, description, mapId, taskID);
                    }
                    return task;
                }
            }
        }

        public List<Tassk> GetTasksByEvent(int eventId)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                List<Tassk> tasks = new List<Tassk>();
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM tasks " +
                    "WHERE event_id = @eventId ORDER BY serial_number ASC", conn))
                {
                    cmd.Parameters.AddWithValue("eventId", eventId);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int taskID = (int)reader["task_id"];
                        int eventID = (int)reader["event_id"];
                        string taskName = reader["task_name"].ToString();
                        string description = reader["task_description"].ToString();
                        int serialNumber = (int)reader["serial_number"];
                        int mapId = (int)reader["map_id"];
                        tasks.Add(new Tassk(eventID, serialNumber, taskName, description, mapId, taskID));
                    }
                    return tasks;
                }
            }
        }

        public void AddTask(int eventID, int serialNumber, string name, string description, int mapID)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(
                 "INSERT INTO tasks (event_id, task_name, task_description, serial_number, map_id) " +
                 "VALUES (@eventId, @taskName, @taskDescription, @serialNumber, @mapId)", conn))
                {
                    cmd.Parameters.AddWithValue("eventId", eventID);
                    cmd.Parameters.AddWithValue("taskName", name);
                    cmd.Parameters.AddWithValue("taskDescription", description);
                    cmd.Parameters.AddWithValue("serialNumber", serialNumber);
                    cmd.Parameters.AddWithValue("mapId", mapID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddMap(string mapLink, string mapName, int eventId)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(
                 "INSERT INTO maps (event_id, map_link, map_name) " +
                 "VALUES (@eventId, @mapLink, @mapName)", conn))
                {
                    cmd.Parameters.AddWithValue("eventId", eventId);
                    cmd.Parameters.AddWithValue("mapLink", mapLink);
                    cmd.Parameters.AddWithValue("mapName", mapName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Map getMap(int mapId)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                Map map = new Map();
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM maps " +
                    "WHERE map_id = @mapId", conn))
                {
                    cmd.Parameters.AddWithValue("mapId", mapId);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int mapID = (int)reader["map_id"];
                        int eventID = (int)reader["event_id"];
                        string mapLink = reader["map_link"].ToString();
                        string mapName = reader["map_name"].ToString();
                        map = new Map(mapLink, eventID, mapName, mapID);
                    }
                    return map;
                }
            }
        }

        public List<Map> GetMapsByEventId(int eventId)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                List<Map> maps = new List<Map>();
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM maps " +
                    "WHERE event_id = @eventId", conn))
                {
                    cmd.Parameters.AddWithValue("eventId", eventId);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int mapID = (int)reader["map_id"];
                        int eventID = (int)reader["event_id"];
                        string mapLink = reader["map_link"].ToString();
                        string mapName = reader["map_name"].ToString();
                        maps.Add(new Map(mapLink, eventID, mapName, mapID));
                    }
                    return maps;
                }
            }
        }

        public int getLastMapId(int eventId)
        {
            int mapID = -1;
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT map_id FROM maps " +
                    "WHERE event_id = @eventId ORDER BY map_id DESC LIMIT 1", conn))
                {
                    cmd.Parameters.AddWithValue("eventId", eventId);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        mapID = (int)reader["map_id"];
                    }
                }
            }
            return mapID;
        }

        public List<Point> GetPointsByTaskId(int taskId)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                List<Point> points = new List<Point>();
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM points " +
                    "WHERE task_id = @taskId", conn))
                {
                    cmd.Parameters.AddWithValue("taskId", taskId);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int taskID = (int)reader["task_id"];
                        int pointID = (int)reader["point_id"];
                        float coordX = (float)reader["coord_x"];
                        float coordY = (float)reader["coord_y"];
                        string pointName = reader["point_name"].ToString();
                        string pointDescription = reader["point_desc"].ToString();
                        //bool rightPoint = (bool)reader["right_point"];
                        points.Add(new Point(taskID, coordX, coordY, pointName, pointDescription));
                    }
                    return points;
                }
            }
        }

        public Map getMapByTaskId(int taskId)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                Map map = new Map();
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM maps " +
                    "WHERE task_id = @taskId", conn))
                {
                    cmd.Parameters.AddWithValue("taskId", taskId);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int mapID = (int)reader["map_id"];
                        int eventID = (int)reader["event_id"];
                        string mapLink = reader["map_link"].ToString();
                        string mapName = reader["map_name"].ToString();
                        map = new Map(mapLink, eventID, mapName, mapID);
                    }
                    return map;
                }
            }
        }

        public void AddPoint(int taskId, float coordX, float coordY, string pointName, string pointDescription)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(
                 "INSERT INTO points (task_id, coord_x, coord_y, point_name, point_desc) " +
                 "VALUES (@taskId, @coordX, @coordY, @pointName, @pointDescription)", conn))
                {
                    cmd.Parameters.AddWithValue("taskId", taskId);
                    cmd.Parameters.AddWithValue("coordX", coordX);
                    cmd.Parameters.AddWithValue("coordY", coordY);
                    cmd.Parameters.AddWithValue("pointName", pointName);
                    cmd.Parameters.AddWithValue("pointDescription", pointDescription);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

