using System;
using System.Collections.Generic;
using System.Linq;


namespace ONLINE_RESELLING_PLATFORM.UserFeedback
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace ONLINE_RESELLING_PLATFORM.UserFeedback
    {
        public class FeedbackManager
        {
            public Dictionary<string, List<string>> sellerFeedbacks = new Dictionary<string, List<string>>(); // Store feedback per seller
            public Dictionary<string, List<int>> sellerRatings = new Dictionary<string, List<int>>(); // Store ratings per seller

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

            // View all seller feedbacks along with ratings
            public void ViewFeedbacks()
            {
                Console.WriteLine("\nSeller Feedbacks:");
                foreach (var kvp in sellerFeedbacks)
                {
                    string seller = kvp.Key;
                    string feedbackList = string.Join(", ", kvp.Value);

                    // Calculate average rating
                    double averageRating = sellerRatings.ContainsKey(seller) && sellerRatings[seller].Count > 0
                        ? sellerRatings[seller].Average()
                        : 0.0;

                    Console.WriteLine($"Seller: {seller}, Reviews: {feedbackList}, Average Rating: {averageRating:F1}/5");
                }
            }

            // View a specific seller's rating
            public void ViewSellerRating(string sellerUsername)
            {
                if (sellerRatings.ContainsKey(sellerUsername) && sellerRatings[sellerUsername].Count > 0)
                {
                    double averageRating = sellerRatings[sellerUsername].Average();
                    Console.WriteLine($"Seller: {sellerUsername}, Average Rating: {averageRating:F1}/5");
                }
                else
                {
                    Console.WriteLine($"No ratings available for seller {sellerUsername}.");
                }
            }
        }
    }

}
