namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Data;
    using Data.Models;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private CarDealerContext context;

        public Deserializer(CarDealerContext context)
        {
            this.context = context;
        }

        public void ImportSuppliers()
        {
            var suppliers =
                JsonConvert.DeserializeObject<Supplier[]>(File.ReadAllText("../../../Datasets/suppliers.json"));

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            Console.WriteLine("Imported suppliers.json");
        }

        public void ImportParts()
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(File.ReadAllText("../../../Datasets/parts.json"));

            var suppliers = context.Suppliers.ToArray();

            var random = new Random();

            foreach (var part in parts) part.Supplier = suppliers[random.Next(suppliers.Length)];

            context.Parts.AddRange(parts);
            context.SaveChanges();

            Console.WriteLine("Imported parts.json");
        }

        public void ImportCars()
        {
            var cars = JsonConvert.DeserializeObject<Car[]>(File.ReadAllText("../../../Datasets/cars.json"));

            var parts = context.Parts.ToArray();

            var random = new Random();

            foreach (var car in cars)
            {
                var count = random.Next(10, 20);

                car.PartCars = new List<PartCar>();

                var addedParts = new HashSet<Part>();

                for (var i = 0; i < count; i++)
                {
                    Part part;

                    do
                    {
                        part = parts[random.Next(parts.Length)];
                    } while (addedParts.Contains(part));

                    addedParts.Add(part);

                    car.PartCars.Add(new PartCar
                    {
                        Part = part
                    });
                }
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            Console.WriteLine("Imported cars.json");
        }

        public void ImportCustomers()
        {
            var customers =
                JsonConvert.DeserializeObject<Customer[]>(File.ReadAllText("../../../Datasets/customers.json"));

            context.Customers.AddRange(customers);
            context.SaveChanges();

            Console.WriteLine("Imported customers.xml");
        }

        public void ImportSales()
        {
            var cars = context.Cars.ToArray();
            var customers = context.Customers.ToArray();
            var discounts = new[] {0M, 0.05M, 0.1M, 0.15M, 0.2M, 0.3M, 0.4M, 0.5M};

            var random = new Random();

            var amount = random.Next(150, 250);

            var sales = new Sale[amount];

            for (var i = 0; i < amount; i++)
                sales[i] = new Sale
                {
                    Car = cars[random.Next(cars.Length)],
                    Customer = customers[random.Next(customers.Length)],
                    Discount = discounts[random.Next(discounts.Length)]
                };

            context.Sales.AddRange(sales);
            context.SaveChanges();
        }
    }
}