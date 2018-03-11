using System;
using System.Collections;
using System.Collections.Generic;
using Wintellect.PowerCollections;
using System.Linq;

public class Instock : IProductStock
{
    private List<Product> byInsertOrder;
    private Dictionary<string, Product> byLabel;
    private Dictionary<int, List<Product>> byQuantity;

    private int currentChangeIndex;

    public Instock()
    {
        byInsertOrder = new List<Product>();
        byLabel = new Dictionary<string, Product>();
        byQuantity = new Dictionary<int, List<Product>>();

        currentChangeIndex = 0;
    }

    public int Count => byInsertOrder.Count;

    public void Add(Product product)
    {
        byInsertOrder.Add(product);
        byLabel.Add(product.Label, product);

        if (!byQuantity.TryGetValue(product.Quantity, out var quantityList))
        {
            quantityList = new List<Product>();
            byQuantity.Add(product.Quantity, quantityList);
        }

        quantityList.Add(product);

        product.ChangeIndex = currentChangeIndex++;
    }

    public void ChangeQuantity(string productLabel, int quantity)
    {
        if (!byLabel.TryGetValue(productLabel, out Product product))
        {
            throw new ArgumentException();
        }

        byQuantity[product.Quantity].Remove(product);

        if (!byQuantity.TryGetValue(quantity, out var quantityList))
        {
            quantityList = new List<Product>();
            byQuantity.Add(quantity, quantityList);
        }

        quantityList.Add(product);

        product.Quantity = quantity;

        product.ChangeIndex = currentChangeIndex++;
    }

    public bool Contains(Product product)
    {
        return byLabel.ContainsKey(product.Label);
    }

    public Product Find(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException();
        }

        return byInsertOrder[index];
    }

    public IEnumerable<Product> FindAllByPrice(double price)
    {
        return byInsertOrder.Where(p => p.Price == price);
    }

    public IEnumerable<Product> FindAllByQuantity(int quantity)
    {
        if (!byQuantity.TryGetValue(quantity, out var quantitySet))
        {
            return Enumerable.Empty<Product>();
        }

        return quantitySet.OrderBy(product => product.ChangeIndex).ToList();
    }

    public IEnumerable<Product> FindAllInRange(double lo, double hi)
    {
        return byInsertOrder.Where(p => p.Price > lo && p.Price <= hi).OrderByDescending(p => p.Price);
    }

    public Product FindByLabel(string label)
    {
        if (!byLabel.TryGetValue(label, out var product))
        {
            throw new ArgumentException();
        }

        return product;
    }

    public IEnumerable<Product> FindFirstByAlphabeticalOrder(int count)
    {
        if (count < 0 || count > Count)
        {
            throw new ArgumentException();
        }

        return byLabel.Take(count).Select(kvp => kvp.Value);
    }

    public IEnumerable<Product> FindFirstMostExpensiveProducts(int count)
    {
        if (count < 0 || count > this.Count)
        {
            throw new ArgumentException();
        }

        return byInsertOrder.OrderByDescending(p => p.Price).Take(count);
    }

    public IEnumerator<Product> GetEnumerator()
    {
        foreach (var product in byInsertOrder)
        {
            yield return product;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
