namespace _08.Use_Your_Chains_Buddy
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class UseYourChainsBuddy
    {
        public static void Main()
        {
            var rgx = new Regex(@"<p>(.+?)<\/p>");
            string result = string.Empty;
            string text = Console.ReadLine();
            foreach (Match match in rgx.Matches(text))
            {
                result += Decrypt(AddSpaces(match.Groups[1].Value));
            }
            Console.WriteLine(result);
        }

        private static string Decrypt(string str)
        {
            var sb = new StringBuilder(str.Length);
            foreach (var c in str)
            {
                char d;
                if (char.IsDigit(c) || c == ' ')
                    d = c;
                else
                    d = (char)(c >= 'n' ? c - 13 : c + 13);
                sb.Append(d);
            }
            return sb.ToString();
        }

        private static string AddSpaces(string str)
        {
            return Regex.Replace(str, @"[^a-z\d]+", " ");
        }
    }
}
