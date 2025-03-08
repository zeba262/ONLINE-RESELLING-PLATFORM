using System;
using System.Collections.Generic;
using System.Linq;

using ONLINE_RESELLING_PLATFORM.Authentication;
using ONLINE_RESELLING_PLATFORM.Initialize;
using ONLINE_RESELLING_PLATFORM.Interfaces;
using ONLINE_RESELLING_PLATFORM.ManageProduct;
using ONLINE_RESELLING_PLATFORM.OrderManagement;
using ONLINE_RESELLING_PLATFORM.UserFeedback.SellerFeedback;



class Program
{
    static List<(string Buyer, int ProductId)> orders = new List<(string, int)>();
    static List<User> users = new List<User>();
    static List<Product> products = new List<Product>();

    static void Main()
    {
        string adminUsername = "admin";
        string adminPassword = "admin123";
        FeedbackManager feedbackManager = new FeedbackManager();


        while (true)
        {
            Console.WriteLine("Welcome to the Online Reselling Platform");
            Console.WriteLine("1. Register\n2. Login\n3. Exit\n");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            if (choice == "1")
                new RegisterUser(users).Execute();
            else if (choice == "2")
            {
                Console.Write("Are you an 1. Admin, 2. Seller, 3. Buyer?: ");
                string userType = Console.ReadLine();

                Console.Write("Enter Username: ");
                string username = Console.ReadLine();
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                if (userType == "1") // Admin
                {
                    if (username == adminUsername && password == adminPassword)
                        new AdminMenu(users, products,feedbackManager).Execute();
                    else
                        Console.WriteLine("Invalid Admin credentials!");
                }
                else if (userType == "2" || userType == "3") // Seller (1) or Buyer (2)
                {
                    string mappedRole = userType == "2" ? "1" : "2";
                    User user = users.FirstOrDefault(u => u.Username == username && u.Password == password && u.Role == mappedRole);
                    if (user != null)
                        new UserMenu(user, products, orders).Execute();
                    else
                        Console.WriteLine("\nInvalid credentials or role! Try again.");
                }
                else
                {
                    Console.WriteLine("\nInvalid choice! Try again.");
                }
            }
            else if (choice == "3")
                return;
            else
                Console.WriteLine("\nInvalid choice! Try again.");
        }
    }
}
