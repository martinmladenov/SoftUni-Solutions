namespace _07.Bomb_Numbers
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var list = Console.ReadLine().Split().Select(int.Parse).ToList();
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bombNumber = arr[0];
            int power = arr[1];
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != bombNumber) continue;
                int startDetonation = i - power;
                if (startDetonation < 0) startDetonation = 0;
                int endDetonation = i + power;
                if (endDetonation >= list.Count) endDetonation = list.Count - 1;
                list.RemoveRange(startDetonation, endDetonation - startDetonation + 1);
                i = 0;
            }
            //Console.WriteLine(string.Join(" ", list));
            Console.WriteLine(list.Sum());
        }
    }
}
