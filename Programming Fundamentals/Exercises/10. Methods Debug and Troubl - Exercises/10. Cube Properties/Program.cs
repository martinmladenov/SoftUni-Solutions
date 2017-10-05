namespace _10.Cube_Properties
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double side = double.Parse(Console.ReadLine());
            string property = Console.ReadLine();
            double result;
            switch (property)
            {
                case "face":
                    result = GetFace(side);
                    break;

                case "space":
                    result = GetSpace(side);
                    break;

                case "volume":
                    result = GetVolume(side);
                    break;

                case "area":
                    result = GetArea(side);
                    break;

                default:
                    result = -1;
                    break;
            }
            Console.WriteLine($"{result:f2}");
        }

        public static double GetFace(double side)
        {
            return Math.Sqrt(2 * Math.Pow(side, 2));
        }

        public static double GetSpace(double side)
        {
            return Math.Sqrt(3 * Math.Pow(side, 2));
        }

        public static double GetVolume(double side)
        {
            return Math.Pow(side, 3);
        }

        public static double GetArea(double side)
        {
            return 6 * Math.Pow(side, 2);
        }
    }
}
