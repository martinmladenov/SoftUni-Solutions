namespace _1.Most_Frequent_Number
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class MostFrequentNumber
    {
        public static void Main()
        {
            var repetitions = new Dictionary<int, int>();
            var numbers = File.ReadAllText("input.txt")
                .Split()
                .Select(int.Parse)
                .ToArray();
            foreach (var number in numbers)
            {
                if (repetitions.ContainsKey(number))
                    repetitions[number]++;
                else
                    repetitions[number] = 1;
            }
            File.WriteAllText("output.txt", repetitions
                .Aggregate((a, b) => a.Value >= b.Value ? a : b)
                .Key.ToString());
        }
    }
}
