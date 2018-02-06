namespace _03._Count_Uppercase_Words
{
    using System;
    using System.Linq;

    public class CountUppercaseWords
    {
        public static void Main()
        {
            string[] words = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> isFirstUpper = s => char.IsUpper(s[0]);
            foreach (var word in words.Where(isFirstUpper))
            {
                Console.WriteLine(word);
            }
        }
    }
}
