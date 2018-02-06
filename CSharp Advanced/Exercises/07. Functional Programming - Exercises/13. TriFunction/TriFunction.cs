namespace _13._TriFunction
{
    using System;

    public class TriFunction
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> charSum = (str, desiredSum) =>
            {
                int sum = 0;
                foreach (var c in str)
                {
                    sum += c;
                }

                return sum >= desiredSum;
            };

            Action<string[], Func<string, int, bool>, int> printNames = (arr, func, desiredSum) =>
            {
                foreach (var name in names)
                {
                    if (func(name, desiredSum))
                    {
                        Console.WriteLine(name);
                        break;
                    }
                }
            };

            printNames(names, charSum, n);

        }
    }
}
