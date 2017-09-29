using System;

namespace _01.Centuries_to_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int centuries = int.Parse(Console.ReadLine());
            Console.WriteLine($"{centuries} centuries = {centuries * 100} years = {(int)(centuries * 100 * 365.2422)} days = {(int)(centuries * 100 * 365.2422) * 24} hours = {(int)(centuries * 100 * 365.2422) * 24 * 60} minutes");
        }
    }
}
