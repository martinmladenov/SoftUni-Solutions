namespace _12._Inferno_III
{
    using System;
    using System.Linq;

    public class Inferno3
    {
        public static void Main()
        {
            int[] gems = Console.ReadLine()
                .Split()
                .Select(int.Parse) // long?
                .ToArray();

            bool[] excluded = new bool[gems.Length];

            string input;
            while ((input = Console.ReadLine()) != "Forge")
            {
                var split = input.Split(';');
                string command = split[0];
                string filterName = split[1];
                int sum = int.Parse(split[2]);

                Predicate<int> filter = null;
                if (filterName == "Sum Left")
                {
                    filter = index => gems[index] == sum || 
                                      index > 0 &&
                                      gems[index] + gems[index - 1] == sum;
                }
                else if (filterName == "Sum Right")
                {
                    filter = index => gems[index] == sum ||
                                      index < gems.Length - 1 &&
                                      gems[index] + gems[index + 1] == sum;
                }
                else if (filterName == "Sum Left Right")
                {
                    filter = index =>
                    {
                        int currSum = gems[index];
                        if (index > 0)
                        {
                            currSum += gems[index - 1];
                        }

                        if (index < gems.Length - 1)
                        {
                            currSum += gems[index + 1];
                        }
                        return currSum == sum;
                    };
                }

                Action<int> mark = null;
                if (command == "Exclude")
                {
                    mark = index => excluded[index] |= filter(index);
                }
                else if (command == "Reverse")
                {
                    mark = index => excluded[index] = !(!excluded[index] | filter(index));
                }

                for (int i = 0; i < gems.Length; i++)
                {
                    mark(i);
                }
            }

            for (int i = 0; i < gems.Length; i++)
            {
                if (!excluded[i])
                {
                    Console.Write(gems[i] + " ");
                }
            }
        }
    }
}
