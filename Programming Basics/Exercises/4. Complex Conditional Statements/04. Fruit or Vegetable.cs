using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var fruits = new List<string> { "banana", "apple", "kiwi", "cherry", "lemon", "grapes" };
            var vegetables = new List<string> { "tomato", "cucumber", "pepper", "carrot" };

            var product = Console.ReadLine();

            if (fruits.Contains(product))
                Console.WriteLine("fruit");
            else if(vegetables.Contains(product))
                Console.WriteLine("vegetable");
            else
                Console.WriteLine("unknown");

        }
    }
}