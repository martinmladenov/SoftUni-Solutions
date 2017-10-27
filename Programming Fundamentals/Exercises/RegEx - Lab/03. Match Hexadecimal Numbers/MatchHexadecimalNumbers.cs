namespace _03.Match_Hexadecimal_Numbers
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchHexadecimalNumbers
    {
        public static void Main()
        {
            var rgx = new Regex($@"\b(?:0x)?[0-9A-F]+\b");
            var nums = Console.ReadLine();
            foreach (Match match in rgx.Matches(nums))
                Console.Write(match.Value + " ");
        }
    }
}
