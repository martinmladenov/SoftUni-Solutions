using System;

namespace _17.Be_Positive
{
    using System.Linq;

    public class BePositive
    {
        public static void Main()
        {
            int countSequences = int.Parse(Console.ReadLine());

            for (int i = 0; i < countSequences; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var numbers = input.Select(int.Parse).ToList();

                bool found = false;

                for (int j = 0; j < numbers.Count; j++)
                {
                    int currentNum = numbers[j];

                    if (currentNum >= 0)
                    {
                        if (found)
                        {
                            Console.Write(" ");
                        }

                        Console.Write(currentNum);

                        found = true;
                    }
                    else if (++j < numbers.Count)
                    {
                        currentNum += numbers[j];

                        if (currentNum >= 0)
                        {
                            if (found)
                            {
                                Console.Write(" ");
                            }

                            Console.Write(currentNum);

                            found = true;
                        }
                    }
                }

                if (!found)
                {
                    Console.Write("(empty)");
                }

                Console.WriteLine();
            }
        }
    }
}
