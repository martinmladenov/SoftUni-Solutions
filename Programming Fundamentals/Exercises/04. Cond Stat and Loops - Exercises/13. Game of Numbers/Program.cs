namespace _13.Game_of_Numbers
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int magic = int.Parse(Console.ReadLine());
            int last1 = -1;
            int last2 = -1;
            int counter = 0;
            for (int i = n; i <= m; i++)
                for (int j = n; j <= m; j++)
                {
                    counter++;
                    if (i + j != magic) continue;
                    last1 = i;
                    last2 = j;
                }
            Console.WriteLine(last1 == -1
                ? $"{counter} combinations - neither equals {magic}"
                : $"Number found! {last1} + {last2} = {magic}");
        }
    }
}
