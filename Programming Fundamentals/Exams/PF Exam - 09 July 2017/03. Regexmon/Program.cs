namespace _03.Regexmon
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var didimonRegex = new Regex(@"[^A-Za-z-]+");
            var bojomonRegex = new Regex(@"[A-Za-z]+-[A-Za-z]+");

            string text = Console.ReadLine();
            for (int i = 0; text.Length > 0; i++)
            {
                var match = (i % 2 == 0 ? didimonRegex : bojomonRegex).Match(text);
                if (!match.Success)
                    break;
                Console.WriteLine(match.Value);
                text = text.Substring(match.Index + match.Length);
            }
        }
    }
}
