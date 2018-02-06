namespace _06._Reverse_And_Exclude
{
    using System;
    using System.Linq;

    public class ReverseAndExclude
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = i => i % n == 0;
            Func<int[], Predicate<int>, int[]> removeIfTrue = (ints, predicate) => ints.Where(i => !predicate(i)).ToArray();
            Func<int[], int[]> reverse = ints => ints.Reverse().ToArray();

            arr = removeIfTrue(arr, isDivisible);
            arr = reverse(arr);
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
