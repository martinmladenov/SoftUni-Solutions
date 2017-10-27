namespace _01.Match_Full_Name
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchFullName
    {
        public static void Main()
        {
            var rgx = new Regex(@"\b[A-Z][a-z]+\s[A-Z][a-z]+\b");
            var names = Console.ReadLine();
            foreach (Match match in rgx.Matches(names))
                Console.Write(match.Value + " ");
        }
    }
}
