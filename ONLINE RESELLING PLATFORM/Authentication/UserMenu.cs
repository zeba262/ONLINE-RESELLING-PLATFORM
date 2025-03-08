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
    public class UserMenu : IUserAction
    {
        public User user;
        public List<Product> products;
        public List<(string Buyer, int ProductId)> orders;

        public UserMenu(User user, List<Product> products, List<(string, int)> orders)
        {
            this.user = user;
            this.products = products;
            this.orders = orders;
        }

        public void Execute()
        {
            FeedbackManager f = new FeedbackManager();
            string choice;
            string sellerUsername, feedback;
            int rating;

            if (user.Role == "1") // Seller
            {
                do
                {
                    Console.WriteLine("\nSeller Menu:");
                    Console.WriteLine("1. View Products");
                    Console.WriteLine("2. Add Product");
                    Console.WriteLine("3. Update Product");
                    Console.WriteLine("4. Delete Product");
                    Console.WriteLine("5. Feedback");
                    Console.WriteLine("6. Logout");
                    Console.Write("Enter your choice: ");
                    choice = Console.ReadLine();

                    if (choice == "1")
                        new ViewProducts(products).Execute();
                    else if (choice == "2")
                        new AddProduct(products, user.Username).Execute();
                    else if (choice == "3")
                        new UpdateProduct(products).Execute();


                    else if (choice == "4")
                        new DeleteProduct(products).Execute();

                    else if (choice == "5")
                    {

                        f.AddSellerFeedback(sellerUsername, feedback, rating);
                        f.ViewFeedbacks();
                        f.ViewSellerRating(sellerUsername);
                    }
                    else if (choice == "6")
                        Console.WriteLine("Logged out successfully!");
                    else
                        Console.WriteLine("Invalid choice, please try again.");

                } while (choice != "6");
            }
            else if (user.Role == "2") // Buyer
            {
                do
                {
                    Console.WriteLine("\nBuyer Menu:");
                    Console.WriteLine("1. View Products");
                    Console.WriteLine("2. Place Order");
                    Console.WriteLine("3. Give Feedback");
                    Console.WriteLine("4. Logout");
                    Console.Write("Enter your choice: ");
                    choice = Console.ReadLine();

                    if (choice == "1")
                        new ViewProducts(products).Execute();
                    else if (choice == "2")
                        new PlaceOrder(products, orders).Execute();
                    else if (choice == "3")
                        new BuyerFeedback(products, orders).Execute();
                    else if (choice == "4")
                        Console.WriteLine("Logged out successfully!");
                    else
                        Console.WriteLine("Invalid choice, please try again.");

                } while (choice != "4");
            }
            else
            {
                Console.WriteLine("Invalid role.");
            }
        }
    }

}
