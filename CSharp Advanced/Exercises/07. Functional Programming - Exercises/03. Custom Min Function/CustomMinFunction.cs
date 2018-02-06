namespace _03._Custom_Min_Function
{
    using System;
    using System.Linq;

    public class CustomMinFunction
    {
        public static void Main()
        {
            int[] ints = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> minFunc = arr =>
            {
                int min = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    if (min > arr[i])
                    {
                        min = arr[i];
                    }
                }

                return min;
            };

            Console.WriteLine(minFunc(ints));
        }
    }
}
