namespace _03.Sum_Adjacent_Equal_Numbers
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var list = Console.ReadLine().Split().Select(double.Parse).ToList();
            bool found = true;
            while (found)
            {
                found = false;
                for (int i = 1; i < list.Count; i++)
                {
                    if (list[i] != list[i - 1]) continue;
                    found = true;
                    list[i - 1] *= 2;
                    list.RemoveAt(i);
                    break;
                }
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
