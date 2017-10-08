namespace _02.Pokemon_Don_t_Go
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var distances = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            long removedSum = 0;
            while (distances.Count > 0)
            {
                int removed;
                int indexToRemove = int.Parse(Console.ReadLine());
                if (indexToRemove < 0)
                {
                    removed = distances[0];
                    distances[0] = distances[distances.Count - 1];
                }
                else if (indexToRemove >= distances.Count)
                {
                    removed = distances[distances.Count - 1];
                    distances[distances.Count - 1] = distances[0];
                }
                else
                {
                    removed = distances[indexToRemove];
                    distances.RemoveAt(indexToRemove);
                }
                removedSum += removed;
                for (var index = 0; index < distances.Count; index++)
                {
                    if (distances[index] <= removed)
                        distances[index] += removed;
                    else
                        distances[index] -= removed;
                }
            }
            Console.WriteLine(removedSum);
        }
    }
}
