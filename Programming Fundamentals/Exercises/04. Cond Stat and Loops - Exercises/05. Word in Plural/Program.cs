using System;

namespace _05.Word_in_Plural
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            if (word.EndsWith("y"))
                word = word.Substring(0, word.Length - 1) + "ies";
            else if (word.EndsWith("o") || word.EndsWith("ch") || word.EndsWith("s") || word.EndsWith("sh") ||
                     word.EndsWith("x") || word.EndsWith("z"))
                word += "es";
            else
                word += 's';
            Console.WriteLine(word);
        }
    }
}
