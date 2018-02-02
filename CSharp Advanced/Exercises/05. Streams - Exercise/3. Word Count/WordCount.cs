namespace _3._Word_Count
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WordCount
    {
        public static void Main()
        {
            var words = new Dictionary<string, int>();

            using (var reader = new StreamReader("words.txt"))
            {
                string word;
                while ((word = reader.ReadLine()) != null)
                {
                    words[word] = 0;
                }
            }

            using (var reader = new StreamReader("text.txt"))
            {
                string data = reader.ReadToEnd();

                foreach (Match match in Regex.Matches(data, @"\w+"))
                {
                    string word = match.Value.ToLower();
                    if (words.ContainsKey(word))
                    {
                        words[word]++;
                    }
                }
            }

            using (var writer = new StreamWriter("result.txt"))
            {
                foreach (var word in words.OrderByDescending(word => word.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
