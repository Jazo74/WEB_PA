using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_PA.Models
{
    public class UserTransit
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Reputation { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
