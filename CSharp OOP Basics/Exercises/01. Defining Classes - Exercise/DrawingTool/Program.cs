// ReSharper disable CheckNamespace

using System;

public class Program
{
    public static void Main()
    {
        string figureType = Console.ReadLine();

        IFigure figure = null;

        if (figureType == "Square")
        {
            int side = int.Parse(Console.ReadLine());
            figure = new Square(side);
        }
        else if (figureType == "Rectangle")
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            figure = new Rectangle(width, height);
        }

        DrawingTool.DrawFigure(figure);
    }
}
