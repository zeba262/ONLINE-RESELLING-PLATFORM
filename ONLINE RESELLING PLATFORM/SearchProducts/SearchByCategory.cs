using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ONLINE_RESELLING_PLATFORM.Initialize;
using ONLINE_RESELLING_PLATFORM.SearchProducts;

namespace ONLINE_RESELLING_PLATFORM.Initialize
{
    public class SearchByCategory : ISearchProduct
    {
        private List<Product> products;

        public SearchByCategory(List<Product> products)
        {
            this.products = products;
        }
        public void Search()
        {
            Console.Write("Enter category to search: ");
            string value = Console.ReadLine();
            var filteredProducts = products
                .Where(p => p.Category.Equals(value, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (filteredProducts.Count>0)
            {
                Console.WriteLine($"\nProducts in Category: {value}");
                foreach (var product in filteredProducts)
                {
                    Console.WriteLine($"\nID: {product.Id}");
                    Console.WriteLine($"Name: {product.Name}");
                    Console.WriteLine($"Model: {product.Model}");
                    Console.WriteLine($"Category: {product.Category}");
                    Console.WriteLine($"Original Price: Rs.{product.OriginalPrice}");
                    Console.WriteLine($"Discounted Price: Rs.{product.DiscountedPrice}");
                    Console.WriteLine($"Description: {product.Description}");
                    Console.WriteLine($"Sold by: {product.Owner}");
                    Console.WriteLine($"Rating: {product.Rating}");
                    Console.WriteLine("Reviews:");
                    if (product.Reviews.Any())
                    {
                        foreach (var review in product.Reviews)
                        {
                            Console.WriteLine($"- {review}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No reviews yet.");
                    }
                }
            }
            else
            {
                Console.WriteLine($"\nNo products found in category '{value}'.");
            }
        }
    }
}

