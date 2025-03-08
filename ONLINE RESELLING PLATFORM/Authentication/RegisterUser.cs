using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ONLINE_RESELLING_PLATFORM.Initialize;
using ONLINE_RESELLING_PLATFORM.Interfaces;

namespace ONLINE_RESELLING_PLATFORM.Authentication
{
    public class RegisterUser : IUserAction
    {
        private List<User> users;

        public RegisterUser(List<User> users)
        {
            this.users = users;
        }

        public void Execute()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter Role (1.Seller  2.Buyer): ");
            string role = Console.ReadLine();

            users.Add(new User(username, password, role));
            Console.WriteLine("Registration successful!");
        }
    }
}
