namespace CarDealer
{
    using System;
    using Data;
    using AutoMapper;

    public class Program
    {
        public static void Main()
        {
            Mapper.Initialize(config => config.AddProfile(new CarDealerProfile()));

            using (CarDealerContext context = new CarDealerContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //Deserializer deserializer = new Deserializer(context);
                //deserializer.ImportSuppliers();
                //deserializer.ImportParts();
                //deserializer.ImportCars();
                //deserializer.ImportCustomers();
                //deserializer.ImportSales();

                Serializer serializer = new Serializer(context);
                Console.WriteLine(serializer.ExportCarsWithDistance());
                Console.WriteLine();
                Console.WriteLine(serializer.ExportCarsFromFerrari());
                Console.WriteLine();
                Console.WriteLine(serializer.ExportLocalSuppliers());
                Console.WriteLine();
                Console.WriteLine(serializer.ExportCarsWithParts());
                Console.WriteLine();
                Console.WriteLine(serializer.ExportCustomerSales());
                Console.WriteLine();
                Console.WriteLine(serializer.ExportSalesWithDiscount());
            }
        }
    }
}
