namespace _03.Safe_Manipulation
{
    using System;
    using System.Linq;

    public static class SafeManipulation
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var command = input.Split();
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
                        if (index < 0 || index >= arr.Length)
                        {
                            Console.WriteLine("Invalid input!");
                            break;
                        }
                        arr[index] = command[2];
                        break;

                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
