using System;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        IsValid = true;
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public bool IsValid { get; private set; }

    public double Length
    {
        get => length;
        private set
        {
            if (value <= 0)
            {
                Console.WriteLine("Length cannot be zero or negative.");
                IsValid = false;
                return;
            }

            length = value;
        }
    }

    public double Width
    {
        get => width;
        private set
        {
            if (value <= 0)
            {
                Console.WriteLine("Width cannot be zero or negative.");
                IsValid = false;
                return;
            }

            width = value;
        }
    }

    public double Height
    {
        get => height;
        private set
        {
            if (value <= 0)
            {
                Console.WriteLine("Height cannot be zero or negative.");
                IsValid = false;
                return;
            }

            height = value;
        }
    }

    public double GetSurfaceArea()
    {
        return 2 * (Width * Height + Length * Height + Length * Width);
    }

    public double GetLateralSurfaceArea()
    {
        return 2 * (Width * Height + Length * Height);
    }

    public double GetVolume()
    {
        return Length * Width * Height;
    }


}
