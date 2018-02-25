using System;
using System.Collections.Generic;
using System.Linq;

class Pizza
{
    private string name;

    public string Name
    {
        get => name;
        private set
        {
            if (value.Length < 1 || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }

    private Dough Dough { get; }

    private List<Topping> Toppings { get; }

    public int NumberOfToppings => Toppings.Count;

    public double TotalCalories
        => Dough.Calories + Toppings.Sum(t => t.Calories);

    public Pizza(string name, Dough dough)
    {
        Name = name;
        Dough = dough;
        Toppings = new List<Topping>();
    }

    public void AddTopping(Topping topping)
    {
        if (NumberOfToppings > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }

        Toppings.Add(topping);
    }
}

