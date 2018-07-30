namespace CarDealer
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Dtos.Export;
    using Microsoft.EntityFrameworkCore;

    public class Serializer
    {
        private CarDealerContext context;

        public Serializer(CarDealerContext context)
        {
            this.context = context;
        }

        public string ExportCarsWithDistance()
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .OrderBy(c => c.Model)
                .ThenBy(c => c.Make)
                .ToArray();

            var carDtos = cars.AsQueryable().ProjectTo<CarWithDistanceDto>().ToArray();

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(carDtos.GetType(), new XmlRootAttribute("cars"));

            serializer.Serialize(new StringWriter(sb), carDtos, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            return sb.ToString();
        }

        public string ExportCarsFromFerrari()
        {
            var cars = context.Cars
                .Where(c => c.Make == "Ferrari")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            var carDtos = cars.AsQueryable().ProjectTo<CarFromFerrariDto>().ToArray();

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(carDtos.GetType(), new XmlRootAttribute("cars"));

            serializer.Serialize(new StringWriter(sb), carDtos, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            return sb.ToString();
        }

        public string ExportLocalSuppliers()
        {
            var suppliers = context.Suppliers
                .Include(s => s.Parts)
                .Where(s => !s.IsImporter)
                .ToArray();

            var supplierDtos = suppliers.AsQueryable().ProjectTo<LocalSupplierDto>().ToArray();

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(supplierDtos.GetType(), new XmlRootAttribute("suppliers"));

            serializer.Serialize(new StringWriter(sb), supplierDtos, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            return sb.ToString();
        }

        public string ExportCarsWithParts()
        {
            var cars = context.Cars
                .Include(c => c.PartCars)
                .ThenInclude(pc => pc.Part)
                .ToArray();

            var carDtos = cars.AsQueryable().ProjectTo<CarDto>().ToArray();

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(carDtos.GetType(), new XmlRootAttribute("cars"));

            serializer.Serialize(new StringWriter(sb), carDtos, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            return sb.ToString();
        }

        public string ExportCustomerSales()
        {
            var customers = context.Customers
                .Include(c => c.Sales)
                .ThenInclude(c => c.Car)
                .ThenInclude(c => c.PartCars)
                .ThenInclude(pc => pc.Part)
                .ToArray();

            var customerDtos = customers
                .Select(c => new CustomerDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s =>
                            s.Car.PartCars.Sum(pc =>
                                pc.Part.Price)
                            * (1 - s.Discount
                                 - (c.IsYoungDriver ? 0.05M : 0M)))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToArray();

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(customerDtos.GetType(), new XmlRootAttribute("customers"));

            serializer.Serialize(new StringWriter(sb), customerDtos, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            return sb.ToString();
        }

        public string ExportSalesWithDiscount()
        {
            var sales = context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Car)
                .ThenInclude(c => c.PartCars)
                .ThenInclude(pc => pc.Part)
                .ToArray();

            var saleDtos = new SaleDto[sales.Length];

            for (int i = 0; i < sales.Length; i++)
            {
                var sale = sales[i];

                var saleDto = Mapper.Map<SaleDto>(sale);

                saleDto.Price = sale.Car.PartCars.Sum(pc => pc.Part.Price);

                saleDto.PriceWithDiscount = sale.Car.PartCars.Sum(pc => pc.Part.Price)
                                            * (1 - sale.Discount -
                                               (sale.Customer.IsYoungDriver ? 0.05M : 0M));

                saleDtos[i] = saleDto;
            }

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(saleDtos.GetType(), new XmlRootAttribute("sales"));

            serializer.Serialize(new StringWriter(sb), saleDtos, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            return sb.ToString();
        }
    }
}
