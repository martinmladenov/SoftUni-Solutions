namespace _02.Match_Phone_Number
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class MatchPhoneNumber
    {
        public static void Main()
        {
            var rgx = new Regex(@"\+359([- ])2\1\d{3}\1\d{4}\b");
            var phones = Console.ReadLine();
            var list = rgx.Matches(phones)
                .Cast<Match>()
                .Select(a => a.Value)
                .ToArray();
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
