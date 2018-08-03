namespace CarDealer
{
    using System.Linq;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class Serializer
    {
        private CarDealerContext context;

        public Serializer(CarDealerContext context)
        {
            this.context = context;
        }

        public string ExportOrderedCustomers()
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Include(c => c.Sales)
                .ThenInclude(s => s.Car)
                .ToArray()
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.BirthDate,
                    c.IsYoungDriver,
                    Sales = c.Sales.Select(s => new
                        {
                            s.Car.Make,
                            s.Car.Model,
                            s.Discount
                        })
                        .ToArray()
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        public string ExportCarsFromToyota()
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray()
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        public string ExportLocalSuppliers()
        {
            var suppliers = context.Suppliers
                .Include(s => s.Parts)
                .Where(c => !c.IsImporter)
                .ToArray()
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }


        public string ExportCarsWithParts()
        {
            var cars = context.Cars
                .Include(c => c.PartCars)
                .ThenInclude(pc => pc.Part)
                .ToArray()
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    parts = c.PartCars.Select(p => new
                    {
                        p.Part.Name,
                        p.Part.Price
                    })
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        public string ExportCustomerSales()
        {
            var customers = context.Customers
                .Include(c => c.Sales)
                .ThenInclude(c => c.Car)
                .ThenInclude(c => c.PartCars)
                .ThenInclude(pc => pc.Part)
                .ToArray()
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(s =>
                        s.Car.PartCars.Sum(pc =>
                            pc.Part.Price)
                        * (1 - s.Discount
                             - (c.IsYoungDriver ? 0.05M : 0M)))
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToArray();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }


        public string ExportSalesWithDiscount()
        {
            var sales = context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Car)
                .ThenInclude(c => c.PartCars)
                .ThenInclude(pc => pc.Part)
                .ToArray()
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount + (s.Customer.IsYoungDriver ? 0.05M : 0M),
                    price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                    priceWithDiscount = s.Car.PartCars.Sum(pc => pc.Part.Price)
                                        * (1 - s.Discount -
                                           (s.Customer.IsYoungDriver ? 0.05M : 0M))
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }
    }
}