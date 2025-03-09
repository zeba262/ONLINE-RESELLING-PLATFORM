using System;
using System.Collections.Generic;
using System.Linq;

namespace ONLINE_RESELLING_PLATFORM.UserFeedback
{
    public class FeedbackManager
    {
        private Dictionary<string, List<string>> sellerFeedbacks = new Dictionary<string, List<string>>(); // Store feedback per seller
        private Dictionary<string, List<int>> sellerRatings = new Dictionary<string, List<int>>(); // Store ratings per seller

        // Add feedback for a seller with rating
        public void AddSellerFeedback(string sellerUsername, string feedback, int rating)
        {
            if (!sellerFeedbacks.ContainsKey(sellerUsername))
            {
                sellerFeedbacks[sellerUsername] = new List<string>();
            }
            sellerFeedbacks[sellerUsername].Add(feedback);

            // Add seller rating
            if (!sellerRatings.ContainsKey(sellerUsername))
            {
                sellerRatings[sellerUsername] = new List<int>();
            }

            // Ensure rating is within 1-5
            if (rating < 1 || rating > 5)
            {
                Console.WriteLine("Invalid rating! Please provide a rating between 1 and 5.");
                return;
            }
            sellerRatings[sellerUsername].Add(rating);
        }

        // View feedback and ratings for all sellers
        public void ViewAllSellerFeedbacksAndRatings()
        {
            Console.WriteLine("\n==== All Seller Feedbacks & Ratings ====");

            if (sellerFeedbacks.Count == 0)
            {
                Console.WriteLine("No feedback available.");
                return;
            }

            foreach (var seller in sellerFeedbacks.Keys)
            {
                string feedbackList = string.Join(", ", sellerFeedbacks[seller]);
                double averageRating = sellerRatings.ContainsKey(seller) && sellerRatings[seller].Count > 0
                    ? sellerRatings[seller].Average()
                    : 0.0;

                Console.WriteLine($"Seller: {seller}");
                Console.WriteLine($"Feedbacks: {feedbackList}");
                Console.WriteLine($"Average Rating: {averageRating:F1}/5\n");
            }
        }
    }
}
