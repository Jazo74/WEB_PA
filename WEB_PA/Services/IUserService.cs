using WEB_PA.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace WEB_PA.Domain
{
    public interface IUserService
    {

        public List<User> GetAllUsers();

        public User GetUserByID(string id);

        public User GetUserByEmail(string email);

        public User Login(string email, string password);

        void AddUser(string email, string password);

        void RegisterUser(string user_id, string email, string password);

    }
}
