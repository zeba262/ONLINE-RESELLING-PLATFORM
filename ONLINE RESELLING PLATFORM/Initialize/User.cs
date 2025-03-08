using System;
using System.Collections.Generic;
using System.Linq;


namespace ONLINE_RESELLING_PLATFORM.Initialize
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // "1" for Seller, "2" for Buyer

        public User(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
