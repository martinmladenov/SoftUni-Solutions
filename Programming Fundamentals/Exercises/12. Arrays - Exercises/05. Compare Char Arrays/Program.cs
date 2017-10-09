namespace _05.Compare_Char_Arrays
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var arr1 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            var arr2 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            int printFirst = arr1.Length < arr2.Length ? 1 : 2;
            for (int i = 0; i < Math.Min(arr1.Length, arr2.Length); i++)
            {
                if (arr1[i] == arr2[i]) continue;
                printFirst = arr1[i] < arr2[i] ? 1 : 2;
            }
            if (printFirst == 1)
            {
                Console.WriteLine(string.Join("", arr1));
                Console.WriteLine(string.Join("", arr2));
            }
            else
            {
                Console.WriteLine(string.Join("", arr2));
                Console.WriteLine(string.Join("", arr1));
            }
        }
    }
}
