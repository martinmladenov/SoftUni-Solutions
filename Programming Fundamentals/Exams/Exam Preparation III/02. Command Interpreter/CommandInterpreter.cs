namespace _02.Command_Interpreter
{
    using System;
    using System.Linq;

    public class CommandInterpreter
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var split = input.Split();
                string[] newArr = null;
                switch (split[0])
                {
                    case "reverse":
                        newArr = Reverse(arr, int.Parse(split[2]), int.Parse(split[4]));
                        break;

                    case "sort":
                        newArr = Sort(arr, int.Parse(split[2]), int.Parse(split[4]));
                        break;

                    case "rollLeft":
                        newArr = Roll(arr, int.Parse(split[1]), true);
                        break;

                    case "rollRight":
                        newArr = Roll(arr, int.Parse(split[1]), false);
                        break;
                }
                if (newArr == null)
                    Console.WriteLine("Invalid input parameters.");
                else
                    arr = newArr;
            }
            Console.WriteLine("[" + string.Join(", ", arr) + "]");
        }

        private static string[] Reverse(string[] arr, int from, int count)
        {
            if (from < 0 || from >= arr.Length || count < 0 || from + count > arr.Length)
                return null;
            return arr
                .Take(from)
                .Concat(
                    arr
                        .Skip(from)
                        .Take(count)
                        .Reverse())
                .Concat(
                    arr
                        .Skip(from + count))
                .ToArray();
        }

        private static string[] Sort(string[] arr, int from, int count)
        {
            if (from < 0 || from >= arr.Length || count < 0 || from + count > arr.Length)
                return null;
            return arr
                .Take(from)
                .Concat(
                    arr
                        .Skip(from)
                        .Take(count)
                        .OrderBy(s => s))
                .Concat(
                    arr
                        .Skip(from + count))
                .ToArray();
        }

        private static string[] Roll(string[] arr, int count, bool left)
        {
            if (count < 0)
                return null;
            if (left)
                count = -count;
            var newArr = new string[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                int newIndex = (i + count) % arr.Length;
                if (newIndex < 0)
                    newIndex += arr.Length;
                newArr[newIndex] = arr[i];
            }

            return newArr;
        }
    }
}
