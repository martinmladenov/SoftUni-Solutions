namespace _04.Cubic_Messages
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class CubicMessages
    {
        public static void Main()
        {
            string input;
            while ((input = Console.ReadLine()) != "Over!")
            {
                int m = int.Parse(Console.ReadLine());
                string rgx = $@"^(\d*)([A-Za-z]{{{m}}})([^A-Za-z]*)$";
                var match = Regex.Match(input, rgx);
                if (!match.Success) continue;
                string text = match.Groups[2].Value;
                string before = match.Groups[1].Value;
                string after = match.Groups[3].Value;
                Console.WriteLine($"{text} == {VerificationCode(text, before + after)}");
            }
        }

        private static string VerificationCode(string text, string digits)
        {
            var sb = new StringBuilder();
            foreach (char c in digits)
            {
                if (c < '0' || c > '9') continue;
                int index = c - '0';
                sb.Append(index < text.Length ? text[index] : ' ');
            }
            return sb.ToString();
        }
    }
}
