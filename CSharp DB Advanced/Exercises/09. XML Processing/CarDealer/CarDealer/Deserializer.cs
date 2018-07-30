namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Dtos.Import;

    public class Deserializer
    {
        private CarDealerContext context;

        public Deserializer(CarDealerContext context)
        {
            this.context = context;
        }

        public void ImportSuppliers()
        {
            var serializer = new XmlSerializer(typeof(SupplierDto[]),
                new XmlRootAttribute("suppliers"));

            var deserializedSuppliers = (SupplierDto[])serializer.Deserialize(
                new MemoryStream(File.ReadAllBytes("../../../Datasets/suppliers.xml")));

            var suppliers = deserializedSuppliers.AsQueryable().ProjectTo<Supplier>().ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            Console.WriteLine("Imported suppliers.xml");
        }

        public void ImportParts()
        {
            var serializer = new XmlSerializer(typeof(PartDto[]),
                new XmlRootAttribute("parts"));

            var deserializedParts = (PartDto[])serializer.Deserialize(
                new MemoryStream(File.ReadAllBytes("../../../Datasets/parts.xml")));

            var parts = deserializedParts.AsQueryable().ProjectTo<Part>().ToArray();

            var suppliers = context.Suppliers.ToArray();

            Random random = new Random();

            foreach (var part in parts)
            {
                part.Supplier = suppliers[random.Next(suppliers.Length)];
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            Console.WriteLine("Imported parts.xml");
        }

        public void ImportCars()
        {
            var serializer = new XmlSerializer(typeof(CarDto[]),
                new XmlRootAttribute("cars"));

            var deserializedCars = (CarDto[])serializer.Deserialize(
                new MemoryStream(File.ReadAllBytes("../../../Datasets/cars.xml")));

            var cars = deserializedCars.AsQueryable().ProjectTo<Car>().ToArray();

            var parts = context.Parts.ToArray();

            Random random = new Random();

            foreach (var car in cars)
            {
                int count = random.Next(10, 20);

                car.PartCars = new List<PartCar>();

                HashSet<Part> addedParts = new HashSet<Part>();

                for (int i = 0; i < count; i++)
                {
                    Part part;

                    do
                    {
                        part = parts[random.Next(parts.Length)];
                    }
                    while (addedParts.Contains(part));

                    addedParts.Add(part);

                    car.PartCars.Add(new PartCar
                    {
                        Part = part
                    });
                }
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            Console.WriteLine("Imported cars.xml");
        }

        public void ImportCustomers()
        {
            var serializer = new XmlSerializer(typeof(CustomerDto[]),
                new XmlRootAttribute("customers"));

            var deserializedCustomers = (CustomerDto[])serializer.Deserialize(
                new MemoryStream(File.ReadAllBytes("../../../Datasets/customers.xml")));

            var customers = deserializedCustomers.AsQueryable().ProjectTo<Customer>().ToArray();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            Console.WriteLine("Imported customers.xml");
        }

        public void ImportSales()
        {
            var cars = context.Cars.ToArray();
            var customers = context.Customers.ToArray();
            var discounts = new[] { 0M, 0.05M, 0.1M, 0.15M, 0.2M, 0.3M, 0.4M, 0.5M };

            Random random = new Random();

            var amount = random.Next(150, 250);

            var sales = new Sale[amount];

            for (int i = 0; i < amount; i++)
            {
                sales[i] = new Sale
                {
                    Car = cars[random.Next(cars.Length)],
                    Customer = customers[random.Next(customers.Length)],
                    Discount = discounts[random.Next(discounts.Length)]
                };
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();
        }
    }
}
