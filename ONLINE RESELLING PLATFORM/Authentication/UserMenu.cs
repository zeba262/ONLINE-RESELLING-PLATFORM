using System;
using System.Collections.Generic;
using ONLINE_RESELLING_PLATFORM.Initialize;
using ONLINE_RESELLING_PLATFORM.Interfaces;
using ONLINE_RESELLING_PLATFORM.ManageProduct;
using ONLINE_RESELLING_PLATFORM.OrderManagement;
using ONLINE_RESELLING_PLATFORM.UserFeedback;
using ONLINE_RESELLING_PLATFORM.SearchProducts;

namespace ONLINE_RESELLING_PLATFORM.Authentication
{
    public class UserMenu : IUserAction
    {
        public User user;
        public List<Product> products;
        public List<(string Buyer, int ProductId)> orders;

        public UserMenu(User user, List<Product> products, List<(string Buyer, int ProductId)> orders)
        {
            this.user = user;
            this.products = products;
            this.orders = orders;
        }

        public void Execute()
        {
            FeedbackManager feedbackManager = new FeedbackManager();
            string choice;

            if (user.Role == "1") // Seller
            {
                do
                {
                    Console.WriteLine("\nSeller Menu:");
                    Console.WriteLine("1. View Products");
                    Console.WriteLine("2. Add Product");
                    Console.WriteLine("3. Update Product");
                    Console.WriteLine("4. Delete Product");
                    Console.WriteLine("5. View & Add Feedback");
                    Console.WriteLine("6. Logout");
                    Console.Write("Enter your choice: ");
                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            new ViewProducts(products).Execute();
                            break;
                        case "2":
                            new AddProduct(products, user.Username).Execute();
                            break;
                        case "3":
                            new UpdateProduct(products).Execute();
                            break;
                        case "4":
                            new DeleteProduct(products).Execute();
                            break;
                        case "5":
                            HandleSellerFeedback(feedbackManager);
                            break;
                        case "6":
                            Console.WriteLine("Logged out successfully!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }

                } while (choice != "6");
            }
            else if (user.Role == "2") // Buyer
            {
                do
                {
                    Console.WriteLine("\nBuyer Menu:");
                    Console.WriteLine("1. View Products");
                    Console.WriteLine("2. Search Products");
                    Console.WriteLine("3. Place Order");
                    Console.WriteLine("4. Give Feedback");
                    Console.WriteLine("5. Logout");
                    Console.Write("Enter your choice: ");
                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            new ViewProducts(products).Execute();
                            break;
                        case "2":
                            Console.Write("Enter search type (1-Product name, 2-Product category): ");
                            string ch = Console.ReadLine();
                            if (ch == "1")
                                new SearchByName(products).Search();
                            else if (ch == "2")
                                new SearchByCategory(products).Search();
                            else 
                                Console.WriteLine("Invalid choice");

                            break;
                        case "3":
                            new PlaceOrder(products, orders).Execute();
                            break;
                        case "4":
                            new BuyerFeedback(products, orders).Execute();
                            break;
                        case "5":
                            Console.WriteLine("Logged out successfully!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }

                } while (choice != "4");
            }
            else
            {
                Console.WriteLine("Invalid role.");
            }
        }

        private void HandleSellerFeedback(FeedbackManager feedbackManager)
        {
            Console.Write("\nEnter Seller Username: ");
            string sellerUsername = Console.ReadLine();

            Console.Write("Enter Feedback: ");
            string feedback = Console.ReadLine();

            int rating;
            do
            {
                Console.Write("Enter Rating (1-5): ");
            } while (!int.TryParse(Console.ReadLine(), out rating) || rating < 1 || rating > 5);

        }

    }

}

