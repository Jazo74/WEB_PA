using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_PA.Domain
{
    public class DBService : IDataService
    {
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
                    "WHERE user_email = @email", conn))
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
    }
}

