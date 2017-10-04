using System;

namespace _01.Blank_Receipt
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PrintReceipt();
        }

        private static void PrintReceipt()
        {
            PrintReceiptHeader();
            PrintReceiptBody();
            PrintReceiptFooter();
        }

        private static void PrintReceiptHeader()
        {
            Console.WriteLine("CASH RECEIPT");
            Console.WriteLine("------------------------------");
        }

        private static void PrintReceiptBody()
        {
            Console.WriteLine("Charged to____________________");
            Console.WriteLine("Received by___________________");
        }

        private static void PrintReceiptFooter()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("\u00A9 SoftUni");
        }
    }
}