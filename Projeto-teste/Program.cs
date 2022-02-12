using Projeto_teste.Entities;
using Projeto_teste.Enums;
using System;
using System.Globalization;

namespace Projeto_teste
{
    class Program
    {
        private static NumberStyles cultureinfo;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string clientName = Console.ReadLine();
            Console.Write("Email: ");
            string clientEmail = Console.ReadLine();
            Console.Write("Birth date (dd/MM/yyyy): ");
            DateTime clientBirthDate;
            DateTime.TryParse(Console.ReadLine(), out clientBirthDate);
            Client client = new Client(clientName, clientEmail, clientBirthDate);

            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status;
            Enum.TryParse(Console.ReadLine(), out status);
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int count;
            int.TryParse(Console.ReadLine(), out count);

            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double productPrice;
                double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture,  out productPrice);
                Console.Write("Quantity: ");
                int quantity;
                int.TryParse(Console.ReadLine(), out quantity);

                Product product = new Product(productName, productPrice);
                OrderItem item = new OrderItem(quantity, product);
                order.AddItem(item);
            }
            Console.Write(order);
        }
    }
}
