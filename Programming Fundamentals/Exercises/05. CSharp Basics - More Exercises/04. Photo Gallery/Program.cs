using System;

namespace _04.Photo_Gallery
{
    class Program
    {
        static void Main(string[] args)
        {
            int photoNumber = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            double size = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            Console.WriteLine($"Name: DSC_{photoNumber:d4}.jpg");
            Console.WriteLine($"Date Taken: {day:d2}/{month:d2}/{year:d4} {hour:d2}:{minutes:d2}");
            string b;
            if (size < 1000)
            {
                b = "B";
            }
            else if (size < 1000000)
            {
                b = "KB";
                size /= 1000;
            }
            else
            {
                b = "MB";
                size /= 1000000;
            }

            Console.WriteLine($"Size: {Math.Round(size, 1)}{b}");
            string orientation;
            if (width == height)
                orientation = "square";
            else if (width > height)
                orientation = "landscape";
            else
                orientation = "portrait";
            Console.WriteLine($"Resolution: {width}x{height} ({orientation})");
        }
    }
}
