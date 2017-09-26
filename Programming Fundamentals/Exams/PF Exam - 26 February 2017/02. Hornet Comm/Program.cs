using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Hornet_Comm
{
    class Program
    {
        static void Main(string[] args)
        {

            var broadcasts = new List<string>();
            var messages = new List<string>();

            var onlyDigitsRegex = new Regex(@"^[0-9]+$");
            var digitsAndLettersRegex = new Regex(@"^[a-zA-Z0-9]+$");
            var anythingButDigitsRegex = new Regex(@"^[^0-9]+$");

            string input;
            while ((input = Console.ReadLine()) != "Hornet is Green")
            {
                if (input == null) continue;
                if (input.Length == 0) continue;

                var queries = input.Split(new[]{ " <-> " }, StringSplitOptions.RemoveEmptyEntries);
                if (queries.Length < 2) continue;

                string firstQuery = queries[0];
                string secondQuery = queries[1];


                if (onlyDigitsRegex.IsMatch(firstQuery) && digitsAndLettersRegex.IsMatch(secondQuery))
                {
                    // private message
                    var arr = firstQuery.ToCharArray();
                    Array.Reverse(arr);
                    string recipientCode = new string(arr);

                    messages.Add($"{recipientCode} -> {secondQuery}");
                }
                else if (anythingButDigitsRegex.IsMatch(firstQuery) && digitsAndLettersRegex.IsMatch(secondQuery))
                {
                    // broadcast
                    string frequency = string.Empty;

                    foreach (var t in secondQuery)
                    {
                        char c = t;
                        if (c >= 'a' && c <= 'z')
                            c -= ' ';
                        else if (c >= 'A' && c <= 'Z')
                            c += ' ';
                        frequency += c;
                    }

                    broadcasts.Add($"{frequency} -> {firstQuery}");
                }
            }

            Console.WriteLine("Broadcasts:");
            Console.WriteLine(broadcasts.Count > 0 ? string.Join("\n", broadcasts) : "None");

            Console.WriteLine("Messages:");
            Console.WriteLine(messages.Count > 0 ? string.Join("\n", messages) : "None");
        }
    }
}
