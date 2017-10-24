namespace _02.Count_Substr_Occurrences
{
    using System;

    public class CountSubstringOccurrences
    {
        public static void Main()
        {
            string str = Console.ReadLine().ToLower();
            string toFind = Console.ReadLine().ToLower();
            int count = -1;
            int index = -1;
            do
            {
                index = str.IndexOf(toFind, index + 1);
                count++;
            } while (index != -1);
            Console.WriteLine(count);
        }
    }
}
