using System;

class Topping
{
    private string type;
    private int weight;

    public Topping(string type, int weight)
    {
        Type = type;
        Weight = weight;
    }

    private string Type
    {
        get => type;
        set
        {
            string lower = value.ToLower();
            if (lower != "meat" && lower != "veggies" &&
                lower != "cheese" && lower != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            type = value;
        }
    }

    private int Weight
    {
        get => weight;
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{Type} weight should be in the range [1..50].");
            }

            weight = value;
        }
    }

    public double Calories
    {
        get
        {
            string lower = Type.ToLower();

            double cal = Weight * 2;

            if (lower == "meat")
            {
                cal *= 1.2;
            }
            else if (lower == "veggies")
            {
                cal *= 0.8;
            }
            else if (lower == "cheese")
            {
                cal *= 1.1;
            }
            else if (lower == "sauce")
            {
                cal *= 0.9;
            }

            return cal;
        }
    }
}

