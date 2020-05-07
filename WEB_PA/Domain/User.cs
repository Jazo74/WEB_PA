using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WEB_PA.Domain
{
    public class User
    {
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }

        public User(string nickName, string email, string password, string firstName, string familyName)
        {
            NickName = nickName;
            Email = email;
            Password = password;
            FirstName = firstName;
            FamilyName = familyName;
        }
    }
}
