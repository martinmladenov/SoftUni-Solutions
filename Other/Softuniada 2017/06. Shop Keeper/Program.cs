using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Shop_Keeper
{
    class Program
    {
        public static int Counter = 0;
        static void Main(string[] args)
        {   
            int[] products = RemoveDuplicates(Array.ConvertAll(Console.ReadLine().Split(), int.Parse)); // -1 = can be replaced
            int[] orders = Array.ConvertAll(Console.ReadLine().Split(), int.Parse); // -2 = fulfilled

            for (int orderIndex = 0; orderIndex < orders.Length; orderIndex++)
            {
                int order = orders[orderIndex];
                if (products.Contains(order))
                {
                    orders[orderIndex] = -2;
                    continue;
                }
                int[] newProducts = ReplaceItem(products, orders, order);
                if (newProducts == null || orderIndex == 0)
                {
                    Console.WriteLine("impossible");
                    return;
                }
                orders[orderIndex] = -2;
                Counter++;
            }
            Console.WriteLine(Counter);

        }

        static int[] ReplaceItem(int[] products, int[] nextOrders, int order)
        {
            for (int i = 0; i < products.Length; i++)
                if (products[i] == -1)
                {
                    products[i] = order;
                    return products;
                }
            for (int i = 0; i < products.Length; i++)
                if (!nextOrders.Contains(products[i]))
                {
                    products[i] = order;
                    return products;
                }
            for (int i = nextOrders.Length - 1; i >= 0; i--)
                for (int j = 0; j < products.Length; j++)
                    if (products[j] == nextOrders[i])
                    {
                        products[j] = order;
                        return products;
                    }
            return null;
        }

        static int[] RemoveDuplicates(int[] products)
        {
            List<int> found = new List<int>();
            for (int i = 0; i < products.Length; i++)
                if (found.Contains(products[i]))
                    products[i] = -1;
                else
                    found.Add(products[i]);
            return products;
        }
    }
}
