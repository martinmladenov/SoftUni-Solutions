namespace _02.Randomize_Words
{
    using System;
    using System.Linq;

    public class RandomizeWords
    {
        public static void Main()
        {
            var list = Console.ReadLine().Split().ToList();
            int length = list.Count;
            var random = new Random();
            for (int i = 0; i < length; i++)
            {
                var word = list[random.Next(list.Count)];
                Console.WriteLine(word);
                list.Remove(word);
            }
        }
    }
}
