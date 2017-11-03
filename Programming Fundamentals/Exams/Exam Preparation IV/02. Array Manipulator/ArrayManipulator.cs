namespace _02.Array_Manipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArrayManipulator
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var split = input.Split();
                switch (split[0])
                {
                    case "exchange":
                        arr = Exchange(arr, int.Parse(split[1]));
                        break;

                    case "max":
                        Max(arr, split[1] == "even");
                        break;

                    case "min":
                        Min(arr, split[1] == "even");
                        break;

                    case "first":
                        First(arr, split[2] == "even", int.Parse(split[1]));
                        break;

                    case "last":
                        Last(arr, split[2] == "even", int.Parse(split[1]));
                        break;
                }
            }
            Console.WriteLine($"[{string.Join(", ", arr)}]");
        }

        private static int[] Exchange(int[] arr, int index)
        {
            if (index >= arr.Length || index < 0)
            {
                Console.WriteLine("Invalid index");
                return arr;
            }
            return arr.Skip(index + 1).Concat(arr.Take(index + 1)).ToArray();
        }

        private static void Max(int[] arr, bool even)
        {
            int maxIndex = -1;
            for (int currIndex = 0; currIndex < arr.Length; currIndex++)
                if (arr[currIndex] % 2 == (even ? 0 : 1) &&
                    (maxIndex == -1 || arr[currIndex] >= arr[maxIndex]))
                    maxIndex = currIndex;
            Console.WriteLine(maxIndex != -1 ? maxIndex.ToString() : "No matches");
        }

        private static void Min(int[] arr, bool even)
        {
            int minIndex = -1;
            for (int currIndex = 0; currIndex < arr.Length; currIndex++)
                if (arr[currIndex] % 2 == (even ? 0 : 1) &&
                    (minIndex == -1 || arr[currIndex] <= arr[minIndex]))
                    minIndex = currIndex;
            Console.WriteLine(minIndex != -1 ? minIndex.ToString() : "No matches");
        }

        private static void First(int[] arr, bool even, int count)
        {
            if (count > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            arr = arr.Where(i => i % 2 == (even ? 0 : 1)).ToArray();
            var list = new List<int>(count);
            for (int i = 0; i < arr.Length && list.Count < count; i++)
                list.Add(arr[i]);
            Console.WriteLine($"[{string.Join(", ", list)}]");
        }

        private static void Last(int[] arr, bool even, int count)
        {
            if (count > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            arr = arr.Where(i => i % 2 == (even ? 0 : 1)).ToArray();
            var list = new List<int>(count);
            for (int i = arr.Length - 1; i >= 0 && list.Count < count; i--)
                list.Add(arr[i]);
            list.Reverse();
            Console.WriteLine($"[{string.Join(", ", list)}]");
        }
    }
}
