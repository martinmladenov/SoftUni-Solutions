namespace _02.Manipulate_Array
{
    using System;
    using System.Linq;

    public static class ManipulateArray
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split();
                switch (command[0])
                {
                    case "Reverse":
                        arr = arr.Reverse().ToArray();
                        break;

                    case "Distinct":
                        arr = arr.Distinct().ToArray();
                        break;

                    case "Replace":
                        int index = int.Parse(command[1]);
                        arr[index] = command[2];
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
