namespace _03.Text_Filter
{
    using System;
    using System.Linq;

    public class TextFilter
    {
        public static void Main()
        {
            var banList = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var text = banList.Aggregate(Console.ReadLine(), (current, word) => current.Replace(word, new string('*', word.Length)));
            Console.WriteLine(text);
        }
    }
}
