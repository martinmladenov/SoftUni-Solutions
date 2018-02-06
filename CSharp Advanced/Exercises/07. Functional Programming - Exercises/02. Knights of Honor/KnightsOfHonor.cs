namespace _02._Knights_of_Honor
{
    using System;

    public class KnightsOfHonor
    {
        public static void Main()
        {
            Action<string> printAction = s => Console.WriteLine($"Sir {s}");
            string[] names = Console.ReadLine().Split();
            foreach (var name in names)
            {
                printAction(name);
            }
        }
    }
}
