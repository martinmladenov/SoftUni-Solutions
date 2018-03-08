namespace ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            ShoppingCenter shoppingCenter = new ShoppingCenter();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                int index = line.IndexOf(' ');
                string command = line.Substring(0, index);
                string[] arguments = line.Substring(index + 1).Split(';');

                switch (command)
                {
                    case "AddProduct":
                        {
                            Product product = new Product(arguments[0], arguments[2], double.Parse(arguments[1]));
                            shoppingCenter.Add(product);
                            Console.WriteLine("Product added");

                        }
                        break;

                    case "DeleteProducts":
                        {
                            int count = arguments.Length == 1
                                ? shoppingCenter.DeleteByProducer(arguments[0])
                                : shoppingCenter.DeleteByNameAndProducer(arguments[0], arguments[1]);

                            if (count == 0)
                                Console.WriteLine("No products found");
                            else
                                Console.WriteLine($"{count} products deleted");
                        }
                        break;

                    case "FindProductsByName":
                        {
                            var products = shoppingCenter.FindByName(arguments[0]);
                            PrintProducts(products);
                        }
                        break;

                    case "FindProductsByProducer":
                        {
                            var products = shoppingCenter.FindByProducer(arguments[0]);
                            PrintProducts(products);
                        }
                        break;

                    case "FindProductsByPriceRange":
                        {
                            double from = double.Parse(arguments[0]);
                            double to = double.Parse(arguments[1]);
                            var products = shoppingCenter.FindByPriceRange(from, to);
                            PrintProducts(products);
                        }
                        break;
                }
            }
        }

        private static void PrintProducts(IEnumerable<Product> products)
        {
            if (products.Any())
                Console.WriteLine(string.Join(Environment.NewLine, products));
            else
                Console.WriteLine("No products found");
        }
    }
}
