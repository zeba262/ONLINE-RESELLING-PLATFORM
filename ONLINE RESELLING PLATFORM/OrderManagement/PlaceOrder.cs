using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ONLINE_RESELLING_PLATFORM.Initialize;
using ONLINE_RESELLING_PLATFORM.Interfaces;

namespace ONLINE_RESELLING_PLATFORM.OrderManagement
{
    public class PlaceOrder : IUserAction
    {
        private List<Product> products;
        private List<(string Buyer, int ProductId)> orders;

        public PlaceOrder(List<Product> products, List<(string, int)> orders)
        {
            this.products = products;
            this.orders = orders;
        }


        public void Execute()
        {
            Console.Write("Enter Product ID to Order: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            Product product = products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                orders.Add(("Buyer", productId));
                Console.WriteLine("Order placed successfully!");
            }
            else
            {
                Console.WriteLine("Invalid Product ID!");
            }
        }
    }
}
