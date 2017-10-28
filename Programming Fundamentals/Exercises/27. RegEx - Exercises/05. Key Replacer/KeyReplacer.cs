namespace _05.Key_Replacer
{
    using System;
    using System.Text.RegularExpressions;

    public class KeyReplacer
    {
        public static void Main()
        {
            var splitKeyRgx = new Regex(@"[\|\\<]+");
            var keys = splitKeyRgx.Split(Console.ReadLine());
            string startKey = keys[0];
            string endKey = keys[keys.Length - 1];
            var messageRgx = new Regex($"{startKey}(.*?){endKey}");
            string message = Console.ReadLine();
            string result = string.Empty;
            foreach (Match match in messageRgx.Matches(message))
                result += match.Groups[1];
            Console.WriteLine(result.Length > 0 ? result : "Empty result");
        }
    }
}
