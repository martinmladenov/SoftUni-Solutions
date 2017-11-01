namespace _03.Rage_Quit
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class RageQuit
    {
        public static void Main()
        {
            string text = Console.ReadLine().ToUpper();
            var rgx = new Regex(@"(?<message>[^\d]+)(?<count>\d+)");
            var result = new StringBuilder();
            foreach (Match match in rgx.Matches(text))
                for (int i = 0; i < int.Parse(match.Groups["count"].Value); i++)
                    result.Append(match.Groups["message"].Value);
            string output = result.ToString();
            Console.WriteLine($"Unique symbols used: {output.Distinct().Count()}");
            Console.WriteLine(output);
        }
    }
}
