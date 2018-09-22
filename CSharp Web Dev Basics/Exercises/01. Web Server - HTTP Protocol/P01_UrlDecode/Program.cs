using System;
using System.Net;

namespace P01_UrlDecode
{
    public class Program
    {
        public static void Main()
        {
            string encodedUrl = Console.ReadLine();
            Console.WriteLine(WebUtility.UrlDecode(encodedUrl));
        }
    }
}