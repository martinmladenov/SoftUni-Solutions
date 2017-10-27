namespace _05.Match_Numbers
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchNumbers
    {
        public static void Main()
        {
            var rgx = new Regex(@"(?:^|(?<=\s))(-?\d+(\.\d+)?)(?:$|(?=\s))");
            var numbers = Console.ReadLine();
            foreach (Match match in rgx.Matches(numbers))
                Console.Write(match.Value + " ");
        }
    }
}
