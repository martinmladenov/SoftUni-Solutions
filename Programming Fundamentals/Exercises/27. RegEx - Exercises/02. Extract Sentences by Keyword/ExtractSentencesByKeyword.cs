namespace _02.Extract_Sentences_by_Keyword
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ExtractSentencesByKeyword
    {
        public static void Main()
        {
            var splitSentencesRgx = new Regex(@"[!.?]+");
            var splitWordsRgx = new Regex(@"[^A-Za-z]+");
            string keyword = Console.ReadLine();
            string text = Console.ReadLine();
            foreach (var sentence in splitSentencesRgx
                .Split(text)
                .Where(sentence =>
                    splitWordsRgx.Split(sentence)
                    .Any(word => word == keyword)))
            {
                Console.WriteLine(sentence);
            }
        }
    }
}
