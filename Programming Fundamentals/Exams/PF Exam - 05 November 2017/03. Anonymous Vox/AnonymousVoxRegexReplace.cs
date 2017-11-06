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
            var values = valueRegex.Matches(valuesText);
            int i = 0;
            text = placeholderRegex.Replace(text, m =>
            {
                if (i < values.Count)
                    return $"{m.Groups[1].Value}{values[i++].Groups[1].Value}{m.Groups[1].Value}"; // i++ returns i and increments it
                return m.Value;
            });
            Console.WriteLine(text);
        }
    }
}
