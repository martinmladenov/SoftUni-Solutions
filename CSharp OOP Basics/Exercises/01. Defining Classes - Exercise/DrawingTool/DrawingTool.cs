// ReSharper disable CheckNamespace

using System;

public static class DrawingTool
{
    public static void DrawFigure(IFigure figure)
    {
        for (int i = 0; i < figure.Height; i++)
        {
            Console.WriteLine($"|{new string(i == 0 || i == figure.Height - 1 ? '-' : ' ', figure.Width)}|");
        }
    }
}
