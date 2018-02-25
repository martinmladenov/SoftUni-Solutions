using System;

public class Program
{
    public static void Main()
    {
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());
        Box parallelepiped = new Box(length, width, height);

        if (parallelepiped.IsValid)
        {
            Console.WriteLine($"Surface Area - {parallelepiped.GetSurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {parallelepiped.GetLateralSurfaceArea():f2}");
            Console.WriteLine($"Volume - {parallelepiped.GetVolume():f2}");
        }
    }
}
