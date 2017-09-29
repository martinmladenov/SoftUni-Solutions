using System;

namespace _08.Ref_Volume_of_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Length: ");
            var length = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            var width = double.Parse(Console.ReadLine());
            Console.Write("Height: "); // Height, not heigth
            var height = double.Parse(Console.ReadLine());
            double volume = length * width * height / 3; // The correct formula is a*b*h/3, not (a+b+h)/3
            Console.WriteLine("Pyramid Volume: {0:F2}", volume);

        }
    }
}
