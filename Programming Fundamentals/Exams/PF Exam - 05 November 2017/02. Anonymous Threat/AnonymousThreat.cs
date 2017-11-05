namespace _02.Anonymous_Threat
{
    using System;
    using System.Linq;

    public class AnonymousThreat
    {
        public static void Main()
        {
            var line = Console.ReadLine().Split();
            string input;
            while ((input = Console.ReadLine()) != "3:1")
            {
                var split = input.Split();
                switch (split[0])
                {
                    case "merge":
                        line = Merge(line, int.Parse(split[1]), int.Parse(split[2]));
                        break;

                    case "divide":
                        line = Divide(line, int.Parse(split[1]), int.Parse(split[2]));
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", line));
        }

        private static string[] Merge(string[] line, int startIndex, int endIndex)
        {
            string merged = string.Empty;
            if (startIndex < 0)
                startIndex = 0;
            if (endIndex >= line.Length)
                endIndex = line.Length - 1;
            for (int i = startIndex; i <= endIndex; i++)
                merged += line[i];
            return line.Take(startIndex)
                .Concat(new[] { merged })
                .Concat(line.Skip(endIndex + 1))
                .ToArray();
        }

        private static string[] Divide(string[] line, int index, int partitions)
        {
            string element = line[index];
            int partitionLength = element.Length / partitions;
            var divided = new string[partitions];
            for (int i = 0; element.Length > partitionLength; i++)
            {
                divided[i] = element.Substring(0, partitionLength);
                element = element.Substring(partitionLength);
            }
            divided[partitions - 1] += element;
            return line.Take(index)
                .Concat(divided)
                .Concat(line.Skip(index + 1))
                .ToArray();
        }
    }
}
