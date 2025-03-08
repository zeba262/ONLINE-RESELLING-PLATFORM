using System;
using System.Collections.Generic;
using System.Linq;
using ONLINE_RESELLING_PLATFORM.Initialize;
using ONLINE_RESELLING_PLATFORM.Interfaces;
using ONLINE_RESELLING_PLATFORM.ManageProduct;
using ONLINE_RESELLING_PLATFORM.OrderManagement;
using ONLINE_RESELLING_PLATFORM.UserFeedback;   

namespace ONLINE_RESELLING_PLATFORM.Authentication
{
    public class AdminMenu
    {
        private List<User> users;
        private List<Product> products;
        private FeedbackManager feedbackManager;

        public AdminMenu(List<User> users, List<Product> products, FeedbackManager feedbackManager)
        {
            this.users = users;
            this.products = products;
            this.feedbackManager = feedbackManager;
        }

        public void Execute()
        {
            while (true)
            {
                Console.WriteLine("\nAdmin Menu:");
                Console.WriteLine("1. View User Details");
                Console.WriteLine("2. View Total Product Count");
                Console.WriteLine("3. View Product Feedback and Ratings");
                Console.WriteLine("4. View Seller Feedback on Software");
                Console.WriteLine("5. View All Products ");
                Console.WriteLine("6. Logout");
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewUserDetails();
                        break;
                    case "2":
                        Console.WriteLine($"Total Products: {products.Count}");
                        break;
                    case "3":
                        new BuyerFeedback.Execute(products,orders);
                        break;
                    case "4":
                        feedbackManager.ViewFeedbacks();
                        feedbackManager.ViewSellerRating(sellerUsername);
                        break;
                    case "5":
                        ViewAllProducts();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }
        }

        private void ViewUserDetails()
        {
            Console.WriteLine("\nUser Details:");
            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.Username}, Role: {(user.Role == "1" ? "Seller" : "Buyer")}");
            }
        }

        private void ViewAllProducts()
        {
            Console.WriteLine("\nAll Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Owner: {product.Owner}, Rating: {product.Rating}");
            }
        }
    }


}
