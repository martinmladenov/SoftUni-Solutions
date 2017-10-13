namespace _09.Jump_Around
{
    using System;
    using System.Linq;

    public static class JumpAround
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;
            int currentElement = 0;
            while (true)
            {
                int step = arr[currentElement];
                sum += step;
                if (currentElement + step < arr.Length)
                {
                    currentElement += step;
                    continue;
                }
                if (currentElement - step >= 0)
                {
                    currentElement -= step;
                    continue;
                }
                break;
            }
            Console.WriteLine(sum);
        }
    }
}
