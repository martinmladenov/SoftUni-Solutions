using System;
using System.Net;

namespace P02_ValidateUrl
{
    public class Program
    {
        public static void Main()
        {
            Uri uri;

            try
            {
                string encodedUrl = Console.ReadLine();
                string url = WebUtility.UrlDecode(encodedUrl);

                uri = new Uri(url);
            }
            catch (Exception)
            {
                uri = null;
            }

            if (uri == null || string.IsNullOrEmpty(uri.Scheme) || string.IsNullOrEmpty(uri.Host) || string.IsNullOrEmpty(uri.AbsolutePath) 
                || uri.Scheme == "http" && uri.Port != 80 || uri.Scheme == "https" && uri.Port != 443)
            {
                Console.WriteLine("Invalid URL");
                return;
            }

            Console.WriteLine($"Protocol: {uri.Scheme}");
            Console.WriteLine($"Host: {uri.Host}");
            Console.WriteLine($"Port: {uri.Port}");
            Console.WriteLine($"Path: {uri.AbsolutePath}");

            if (!string.IsNullOrEmpty(uri.Query))
            {
                Console.WriteLine($"Query: {uri.Query.TrimStart('?')}");
            }

            if (!string.IsNullOrEmpty(uri.Fragment))
            {
                Console.WriteLine($"Fragment: {uri.Fragment.TrimStart('#')}");
            }
        }
    }
}