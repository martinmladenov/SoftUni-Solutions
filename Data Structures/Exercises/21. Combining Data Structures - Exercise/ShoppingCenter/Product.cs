// ReSharper disable StringCompareToIsCultureSpecific
namespace ShoppingCenter
{
    using System;
    public class Product : IComparable<Product>
    {
        public Product(string name, string producer, double price)
        {
            Name = name;
            Producer = producer;
            Price = price;
        }

        public string Name { get; }
        public string Producer { get; }
        public double Price { get; }

        public int CompareTo(Product other)
        {
            int cmp = Name.CompareTo(other.Name);
            if (cmp == 0)
            {
                cmp = Producer.CompareTo(other.Producer);
                if (cmp == 0)
                {
                    cmp = Price.CompareTo(other.Price);
                }
            }

            return cmp;
        }

        public override string ToString()
        {
            return "{" + $"{Name};{Producer};{Price:f2}" + "}";
        }
    }
}
