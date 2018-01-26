namespace _08.Recursive_Fibonacci
{
    using System;
    using System.Collections.Generic;

    public class RecursiveFibonacci
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var memoizationDictionary = new Dictionary<int, long>()
            {
                {1, 1},
                {2, 1}
            };

            Console.WriteLine(GetFibonacci(n, memoizationDictionary));

        }

        private static long GetFibonacci(int n, Dictionary<int, long> memoizationDictionary)
        {
            if (memoizationDictionary.ContainsKey(n))
                return memoizationDictionary[n];

            long fib = GetFibonacci(n - 1, memoizationDictionary) + GetFibonacci(n - 2, memoizationDictionary);

            memoizationDictionary[n] = fib;

            return fib;
        }
    }
}
