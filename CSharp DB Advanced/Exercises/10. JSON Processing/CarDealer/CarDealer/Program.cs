namespace CarDealer
{
    using System;
    using Data;

    public class Program
    {
        public static void Main()
        {
            using (var context = new CarDealerContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var deserializer = new Deserializer(context);
                deserializer.ImportSuppliers();
                deserializer.ImportParts();
                deserializer.ImportCars();
                deserializer.ImportCustomers();
                deserializer.ImportSales();

                var serializer = new Serializer(context);
                Console.WriteLine(serializer.ExportOrderedCustomers());
                Console.WriteLine();
                Console.WriteLine(serializer.ExportCarsFromToyota());
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