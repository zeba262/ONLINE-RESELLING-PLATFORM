using System;
using System.Collections.Generic;
using System.Linq;

using ONLINE_RESELLING_PLATFORM.Initialize;
using ONLINE_RESELLING_PLATFORM.Interfaces;

namespace ONLINE_RESELLING_PLATFORM.ManageProduct
{
    public class DeleteProduct : IUserAction
    {
        private List<Product> products;

        public DeleteProduct(List<Product> products)
        {
            this.products = products;
        }

        public void Execute()
        {
            Console.Write("Enter Product ID to Delete: ");
            int productId = Convert.ToInt32(Console.ReadLine());

            Product product = products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine("\nProduct deleted successfully!");
            }
            else
            {
                Console.WriteLine("\nProduct not found!");
            }
        }
    }
}
