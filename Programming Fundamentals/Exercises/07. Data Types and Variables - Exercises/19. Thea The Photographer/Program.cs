using System;

namespace _19.Thea_The_Photographer
{
    class Program
    {
        static void Main(string[] args)
        {
            long numberOfPictures = long.Parse(Console.ReadLine());
            long filterTime = long.Parse(Console.ReadLine());
            double filterFactor = long.Parse(Console.ReadLine()) / 100d;
            long uploadTime = long.Parse(Console.ReadLine());

            long time = numberOfPictures * filterTime + (long)Math.Ceiling(numberOfPictures * filterFactor) * uploadTime;

            long days = time / 86400;
            time %= 86400;
            long hours = time / 3600;
            time %= 3600;
            long minutes = time / 60;
            time %= 60;
            long seconds = time;

            Console.WriteLine($"{days}:{hours:d2}:{minutes:d2}:{seconds:d2}");
        }
    }
}
