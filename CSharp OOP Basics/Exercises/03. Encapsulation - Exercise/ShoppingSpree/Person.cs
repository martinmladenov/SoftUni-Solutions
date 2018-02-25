using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bag;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.bag = new List<Product>();
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            name = value;
        }
    }

    public decimal Money
    {
        get => money;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            money = value;
        }
    }

    public bool BuyProduct(Product product)
    {
        if (product.Cost > money)
        {
            return false;
        }

        bag.Add(product);
        Money -= product.Cost;

        return true;
    }

    public override string ToString()
    {
        return $"{Name} - {(bag.Count == 0 ? "Nothing bought" : string.Join(", ", bag))}";
    }
}
