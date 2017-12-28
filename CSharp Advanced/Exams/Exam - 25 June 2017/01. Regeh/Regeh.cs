namespace _01.Regeh
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Regeh
    {
        public static void Main()
        {
            var rgx = new Regex(@"\[[^\[\]\s]+<(\d+)REGEH(\d+)>[^\[\]\s]+\]");
            var input = Console.ReadLine();
            var matches = rgx.Matches(input);
            var indexes = new int[matches.Count * 2];
            for (var i = 0; i < matches.Count; i++)
            {
                var match = matches[i];
                indexes[i * 2] = (int.Parse(match.Groups[1].Value) + (i == 0 ? 0 : indexes[i * 2 - 1])) % input.Length;
                indexes[i * 2 + 1] = (int.Parse(match.Groups[2].Value) + indexes[i * 2]) % input.Length;
            }
            Console.WriteLine(string.Join("", indexes.Select(index => input[index])));
        }
    }
}
