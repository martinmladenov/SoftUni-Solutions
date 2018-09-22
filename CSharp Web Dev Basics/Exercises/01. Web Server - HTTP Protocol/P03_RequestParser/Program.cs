using System;
using System.Collections.Generic;
using System.Text;

namespace P03_RequestParser
{
    public class Program
    {
        public static void Main()
        {
            var paths = new Dictionary<string, HashSet<string>>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                int separatorIndex = input.LastIndexOf('/');

                string method = input.Substring(separatorIndex + 1).ToUpper();

                string path = input.Substring(0, separatorIndex).ToLower();

                if (!paths.ContainsKey(method))
                {
                    paths.Add(method, new HashSet<string>());
                }

                paths[method].Add(path);
            }

            string[] request = Console.ReadLine().Split();

            string reqMethod = request[0].ToUpper();
            string reqPath = request[1].ToLower();

            string statusCode;
            string responseText;

            if (paths.ContainsKey(reqMethod) && paths[reqMethod].Contains(reqPath))
            {
                statusCode = "200 OK";
                responseText = "OK";
            }
            else
            {
                statusCode = "404 NotFound";
                responseText = "NotFound";
            }

            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"HTTP/1.1 {statusCode}");
            sb.AppendLine($"Content-Length: {responseText.Length}");
            sb.AppendLine($"Content-Type: text/plain");
            sb.AppendLine();
            sb.Append(responseText);

            Console.WriteLine(sb);
        }
    }
}