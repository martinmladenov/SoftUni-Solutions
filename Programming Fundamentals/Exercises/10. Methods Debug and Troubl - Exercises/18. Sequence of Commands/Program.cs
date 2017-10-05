using System;
using System.Linq;

namespace _18.Sequence_of_Commands
{
    public class SequenceOfCommands
    {
        private const char ArgumentsDelimiter = ' ';

        public static void Main()
        {
            int sizeOfArray = int.Parse(Console.ReadLine());

            long[] array = Console.ReadLine()
                .Split(ArgumentsDelimiter)
                .Select(long.Parse)
                .ToArray();

            string command = Console.ReadLine();

            while (!command.Equals("stop"))
            {
                var line = command.Split(ArgumentsDelimiter);
                int[] args = new int[2];

                if (line[0].Equals("add") ||
                    line[0].Equals("subtract") ||
                    line[0].Equals("multiply"))
                {
                    args[0] = int.Parse(line[1]) - 1;
                    args[1] = int.Parse(line[2]);
                }

                PerformAction(array, line[0], args);

                PrintArray(array);

                command = Console.ReadLine();
            }
        }

        private static void PerformAction(long[] array, string action, int[] args)
        {
            int pos = args[0];
            int value = args[1];

            switch (action)
            {
                case "multiply":
                    array[pos] *= value;
                    break;

                case "add":
                    array[pos] += value;
                    break;

                case "subtract":
                    array[pos] -= value;
                    break;

                case "lshift":
                    ArrayShiftLeft(array);
                    break;

                case "rshift":
                    ArrayShiftRight(array);
                    break;
            }
        }

        private static void ArrayShiftRight(long[] array)
        {
            var copy = array.Clone() as long[];
            array[0] = copy[copy.Length - 1];
            for (int i = 1; i < array.Length; i++)
            {
                array[i] = copy[i - 1];
            }
        }

        private static void ArrayShiftLeft(long[] array)
        {
            var copy = array.Clone() as long[];
            array[array.Length - 1] = copy[0];
            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = copy[i + 1];
            }
        }

        private static void PrintArray(long[] array)
        {
            foreach (long t in array)
            {
                Console.Write(t + " ");
            }
            Console.WriteLine();
        }
    }
}
