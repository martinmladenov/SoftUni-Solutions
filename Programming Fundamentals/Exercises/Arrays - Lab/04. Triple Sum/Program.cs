namespace _04.Triple_Sum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            bool found = false;
            for (int aIndex = 0; aIndex < arr.Length; aIndex++)
                for (int bIndex = aIndex + 1; bIndex < arr.Length; bIndex++)
                    for (int cIndex = 0; cIndex < arr.Length; cIndex++)
                        if ((long)arr[aIndex] + arr[bIndex] == arr[cIndex])
                        {
                            Console.WriteLine($"{arr[aIndex]} + {arr[bIndex]} == {arr[cIndex]}");
                            found = true;
                            break;
                        }
            if (!found)
                Console.WriteLine("No");
        }
    }
}
