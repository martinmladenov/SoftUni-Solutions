namespace _2.Index_of_Letters
{
    using System.IO;
    using System.Linq;

    public class IndexOfLetters
    {
        public static void Main()
        {
            string str = File.ReadAllText("input.txt");
            var output = str.Select(c => c + " -> " + (c - 'a')).ToArray();
            File.WriteAllLines("output.txt", output);
        }
    }
}
