namespace _01.Extract_Emails
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractEmails
    {
        public static void Main()
        {
            var rgx = new Regex(@"(^|(?<=\s))(?:[A-Za-z0-9](?:[-._]*[A-Za-z0-9])*)@(?:(?:[A-Za-z](?:-*[A-Za-z])*)(?:\.[A-Za-z](?:-*[A-Za-z])*)+)");
            var text = Console.ReadLine();
            foreach (Match match in rgx.Matches(text))
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
