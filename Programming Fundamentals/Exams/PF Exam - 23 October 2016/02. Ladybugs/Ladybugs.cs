namespace _02.Ladybugs
{
    using System;
    using System.Linq;

    public class Ladybugs
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            var field = new bool[size];
            foreach (int i in Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(i => i >= 0 && i < size))
                field[i] = true;
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var split = input.Split();
                int index = int.Parse(split[0]);
                int direction = split[1] == "left" ? -1 : 1;
                int steps = int.Parse(split[2]) * direction;
                if (index < 0 || index >= size ||
                    !field[index])
                    continue;
                field[index] = false;
                while ((index += steps) >= 0 && index < size)
                {
                    if (field[index]) continue;
                    field[index] = true;
                    break;
                }
            }
            Console.WriteLine(string.Join(" ", field.Select(b => b ? 1 : 0)));
        }
    }
}
