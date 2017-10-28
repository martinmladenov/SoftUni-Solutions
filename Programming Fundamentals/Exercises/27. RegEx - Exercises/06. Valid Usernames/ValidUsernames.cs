namespace _06.Valid_Usernames
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ValidUsernames
    {
        public static void Main()
        {
            var rgx = new Regex(@"(?:^|(?<=[ \/\\()]))([A-Za-z]\w{2,24})(?:$|(?=[ \/\\()]))");
            var text = Console.ReadLine();
            var usernames = rgx.Matches(text)
                .Cast<Match>()
                .Select(u => u.Groups[1])
                .ToArray();
            int longestIndex = -1;
            int longestLength = -1;
            for (int i = 0; i < usernames.Length - 1; i++)
            {
                int length = usernames[i].Length + usernames[i + 1].Length;
                if (longestLength >= length) continue;
                longestLength = length;
                longestIndex = i;
            }
            Console.WriteLine(usernames[longestIndex]);
            Console.WriteLine(usernames[longestIndex + 1]);
        }
    }
}
