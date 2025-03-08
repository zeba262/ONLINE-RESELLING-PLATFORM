using System;
using System.Collections.Generic;
using System.Linq;

using ONLINE_RESELLING_PLATFORM.Initialize;
using ONLINE_RESELLING_PLATFORM.Interfaces;

namespace ONLINE_RESELLING_PLATFORM.UserFeedback
{
    public class BuyerFeedback : IUserAction
    {
        private List<Product> products;
        private List<(string Buyer, int ProductId)> orders;

        public BuyerFeedback(List<Product> products, List<(string, int)> orders)
        {
            this.products = products;
            this.orders = orders;
        }

        public void Execute()
        {
            Console.Write("Enter Product ID to Review: ");
            int productId = Convert.ToInt32(Console.ReadLine());

            // Check if the buyer has purchased the product before allowing feedback
            if (!orders.Any(o => o.Buyer == "Buyer" && o.ProductId == productId))
            {
                Console.WriteLine("\nYou can only review purchased products!");
                return;
            }

            // Asking for the rating (1 to 5 stars)
            Console.Write("Enter Your Rating (1 to 5 stars): ");
            int rating = Convert.ToInt32(Console.ReadLine());
            if (rating < 1 || rating > 5)
            {
                Console.WriteLine("\nInvalid rating! Please enter a value between 1 and 5.");
                return;
            }

            // Asking for the text review
            Console.Write("Enter Your Review: ");
            string review = Console.ReadLine();

            // Find the product to add the review
            var product = products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                // Add the review text to the product
                product.Reviews.Add(review);

                // Update the product's average rating
                product.Rating = (product.Rating * product.Reviews.Count + rating) / (product.Reviews.Count + 1);

                Console.WriteLine("\nFeedback submitted successfully!");
                Console.WriteLine($"New Average Rating for {product.Name}: {product.Rating:F1} stars");
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }
    }



}
