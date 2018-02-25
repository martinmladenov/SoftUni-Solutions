using System;

class Dough
{
    private string flourType;
    private string bakingTechnique;
    private int weight;

    public Dough(string flourType, string bakingTechnique, int weight)
    {
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }

    private string FlourType
    {
        get => flourType;
        set
        {
            string lower = value.ToLower();
            if (lower != "white" && lower != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            flourType = lower;
        }
    }

    private string BakingTechnique
    {
        get => bakingTechnique;
        set
        {
            string lower = value.ToLower();
            if (lower != "crispy" && lower != "chewy" && lower != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            bakingTechnique = lower;
        }
    }

    private int Weight
    {
        get => weight;
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            weight = value;
        }
    }

    public double Calories
    {
        get
        {
            double cal = Weight * 2;

            if (FlourType == "white")
            {
                cal *= 1.5;
            }

            if (BakingTechnique == "crispy")
            {
                cal *= 0.9;
            }
            else if (BakingTechnique == "chewy")
            {
                cal *= 1.1;
            }

            return cal;
        }
    }
}

