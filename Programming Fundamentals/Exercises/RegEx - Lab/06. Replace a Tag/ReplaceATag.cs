namespace _06.Replace_a_Tag
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ReplaceATag
    {
        public static void Main()
        {
            var pattern = new Regex(@"<a href=""(.*)"">(.*)<\/a>");
            var replacement = @"[URL href=""$1""]$2[/URL]";
            var toPrint = new List<string>();
            string input;
            while ((input = Console.ReadLine()) != "end")
                toPrint.Add(pattern.Replace(input, replacement));
            Console.WriteLine(string.Join(Environment.NewLine, toPrint));
        }
    }
}
