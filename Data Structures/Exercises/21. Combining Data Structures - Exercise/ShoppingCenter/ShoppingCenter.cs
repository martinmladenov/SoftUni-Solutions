namespace ShoppingCenter
{
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class ShoppingCenter
    {
        private Dictionary<string, OrderedBag<Product>> byName;
        private Dictionary<string, OrderedBag<Product>> byProducer;
        private Dictionary<string, Bag<Product>> byNameAndProducer;
        private OrderedDictionary<double, Bag<Product>> byPrice;

        public ShoppingCenter()
        {
            byName = new Dictionary<string, OrderedBag<Product>>();
            byProducer = new Dictionary<string, OrderedBag<Product>>();
            byNameAndProducer = new Dictionary<string, Bag<Product>>();
            byPrice = new OrderedDictionary<double, Bag<Product>>();
        }

        public void Add(Product product)
        {
            if (!byName.ContainsKey(product.Name))
                byName.Add(product.Name, new OrderedBag<Product>());
            byName[product.Name].Add(product);

            if (!byProducer.ContainsKey(product.Producer))
                byProducer.Add(product.Producer, new OrderedBag<Product>());
            byProducer[product.Producer].Add(product);

            string nameAndProducer = product.Name + ";" + product.Producer;
            if (!byNameAndProducer.ContainsKey(nameAndProducer))
                byNameAndProducer.Add(nameAndProducer, new Bag<Product>());
            byNameAndProducer[nameAndProducer].Add(product);

            if (!byPrice.ContainsKey(product.Price))
                byPrice.Add(product.Price, new Bag<Product>());
            byPrice[product.Price].Add(product);

        }

        public IEnumerable<Product> FindByName(string name)
        {
            if (!byName.ContainsKey(name))
            {
                return Enumerable.Empty<Product>();
            }

            return byName[name];
        }

        public IEnumerable<Product> FindByProducer(string producer)
        {
            if (!byProducer.ContainsKey(producer))
            {
                return Enumerable.Empty<Product>();
            }

            return byProducer[producer];
        }

        public IEnumerable<Product> FindByPriceRange(double from, double to)
        {
            OrderedBag<Product> ob = new OrderedBag<Product>();
            foreach (var bag in byPrice.Range(from, true, to, true))
            {
                ob.AddMany(bag.Value);
            }

            return ob;
        }

        public int DeleteByProducer(string producer)
        {
            if (!byProducer.ContainsKey(producer))
            {
                return 0;
            }

            var toDelete = byProducer[producer];
            int count = toDelete.Count;

            foreach (var product in toDelete)
            {
                byName[product.Name].Remove(product);
                byNameAndProducer[product.Name + ";" + product.Producer].Remove(product);
                byPrice[product.Price].Remove(product);
            }

            byProducer.Remove(producer);

            return count;
        }

        public int DeleteByNameAndProducer(string name, string producer)
        {
            string nameAndProducer = name + ";" + producer;

            if (!byNameAndProducer.ContainsKey(nameAndProducer))
            {
                return 0;
            }

            var toDelete = byNameAndProducer[nameAndProducer];
            int count = toDelete.Count;

            foreach (var product in toDelete)
            {
                byName[product.Name].Remove(product);
                byProducer[product.Producer].Remove(product);
                byPrice[product.Price].Remove(product);
            }

            byNameAndProducer.Remove(name + ";" + producer);

            return count;
        }
    }
}
