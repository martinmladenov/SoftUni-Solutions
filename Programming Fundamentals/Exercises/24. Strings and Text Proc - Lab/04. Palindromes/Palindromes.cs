namespace _04.Palindromes
{
    using System;
    using System.Linq;

    public class Palindromes
    {
        public static void Main()
        {
            var words = Console.ReadLine()
                .Split(new[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            var palindromes = words
                .Where(IsPalindrome)
                .Distinct()
                .OrderBy(s => s);
            Console.WriteLine(string.Join(", ", palindromes));
        }

        private static bool IsPalindrome(string word)
        {
            for (int i = 0; i < word.Length / 2; i++)
                if (word[i] != word[word.Length - 1 - i])
                    return false;
            return true;
        }
    }
}
