namespace _01.Largest_Common_End
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var arr1 = Console.ReadLine().Split(' ');
            var arr2 = Console.ReadLine().Split(' ');

            int commonLeft = 0;
            bool scanLeft = true;
            int commonRight = 0;
            bool scanRight = true;
            for (int i = 0; i < Math.Min(arr1.Length, arr2.Length); i++)
            {
                if (scanLeft)
                {
                    if (arr1[i] == arr2[i])
                        commonLeft++;
                    else
                        scanLeft = false;
                }

                if (scanRight)
                {
                    if (arr1[arr1.Length - i - 1] == arr2[arr2.Length - i - 1])
                        commonRight++;
                    else
                        scanRight = false;
                }
            }
            Console.WriteLine(Math.Max(commonLeft, commonRight));
        }
    }
}
