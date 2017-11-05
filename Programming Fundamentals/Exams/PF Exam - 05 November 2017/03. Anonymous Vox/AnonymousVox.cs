namespace _03.Anonymous_Vox
{
    using System;
    using System.Text.RegularExpressions;

    public class AnonymousVox
    {
        public static void Main()
        {
            var placeholderRegex = new Regex(@"([A-Za-z]+).+\1");
            var valueRegex = new Regex(@"{(.+?)}");
            string text = Console.ReadLine();
            string valuesText = Console.ReadLine();
            var placeholders = placeholderRegex.Matches(text);
            var values = valueRegex.Matches(valuesText);
            for (int i = 0; i < Math.Min(values.Count, placeholders.Count); i++)
            {
                string value = values[i].Groups[1].Value;
                var placeholder = placeholders[i];
                string replacement = $"{placeholder.Groups[1].Value}{value}{placeholder.Groups[1].Value}";
                int startIndex = text.IndexOf(placeholder.Value);
                text = text.Substring(0, startIndex) + replacement
                       + text.Substring(startIndex + placeholder.Length);
            }
            Console.WriteLine(text);
        }
    }
}
