using ProjetoPedidos.Entities;
using ProjetoPedidos.Entities.Enums;
using System;
using System.Globalization;

namespace ProjetoPedidos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, date);

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How to many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1 ; i <= n; i++)
            {
                
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product Name: ");
                string productName = (Console.ReadLine());
                Console.Write("Product Price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int productQuantity = int.Parse(Console.ReadLine());
               
                Product product = new Product(productName, productPrice);
                OrderItem item = new OrderItem(productQuantity,productPrice, product);
                order.AddOrderItem(item);
            }

            Console.WriteLine(order);
        }
    }
}
