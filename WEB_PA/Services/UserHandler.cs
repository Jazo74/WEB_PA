using WEB_PA.Domain;
using WEB_PA.Models;
using Newtonsoft.Json.Schema;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_PA.Services
{
    public class UserHandler : IUserService
    {
        //Missing available users
        private List<User> users = new List<User>();

        private List<UserTransit> users2 = new List<UserTransit>();


        // gets all users from the DataBase

        public List<User> GetAllUsers()
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM users", conn))
                {
                    List<User> userList = new List<User>();
                    string nickName = "";
                    string email = "";
                    string password = "";
                    string firstName = "";
                    string familyName = "";

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        nickName = reader["nickname"].ToString();
                        email = reader["user_email"].ToString();
                        password = reader["pw"].ToString();
                        firstName = reader["first_name"].ToString();
                        familyName = reader["family_name"].ToString();

                        users.Add(new User(nickName, email, password, firstName, familyName));
                    }

                    return users;
                }
            }
        }


        //public User GetUserByEmail(string email)
        //{
        //    return users.FirstOrDefault(u => u.Email == email);
        //}


        //public User Login(string email, string password)
        //{

        //    var user = GetUserByEmail(email);
        //    if (user == null)
        //    {
        //        return null;
        //    }
        //    if (user.Password != password)
        //    {
        //        return null;
        //    }
        //    return user;
        //}

        //DataBase 


        public string GetPasswordByEmail(string email)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT pw FROM users WHERE user_email = @email", conn))
                {
                    List<User> userList = new List<User>();
                    string password = "";
                    cmd.Parameters.AddWithValue("email", email);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        password = reader["pw"].ToString();
                    }
                    return password;
                }
            }
        }

        public void AddUser(string email, string password)
        {
            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO user (email, password) VALUES (@email, @password)"))
                {
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.Parameters.AddWithValue("password", password);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void RegisterUser(User user)
        {
            DateTime registration_date = DateTime.Now;

            using (var conn = new NpgsqlConnection(Program.ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO users (nickname, user_email, pw, first_name, family_name) VALUES(@nickName, @email, @password, @firstName, @familyName)", conn))
                {
                    cmd.Parameters.AddWithValue("@nickName", user.NickName);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@familyName", user.FamilyName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //public List<UserTransit> GetAllUsersModel()
        //{
        //    DateTime registrationDate = DateTime.Now;
        //    using (var conn = new NpgsqlConnection(Program.ConnectionString))
        //    {
        //        conn.Open();
        //        using (var cmd = new NpgsqlCommand("SELECT * FROM \"user\"", conn))
        //        {
        //            string id = "";
        //            string email = "";
        //            string password = "";
        //            int reputation = 0;

        //            var reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                id = reader["user_id"].ToString();
        //                email = reader["email"].ToString();
        //                password = reader["password"].ToString();
        //                reputation = Convert.ToInt32(reader["reputation"]);
        //                registrationDate = Convert.ToDateTime(reader["registration_date"]);
        //                _users2.Add(new UserTransit(id, email, password, reputation, registrationDate));
        //            }
        //            return _users2;
        //        }
        //    }
        //}

    }
}
