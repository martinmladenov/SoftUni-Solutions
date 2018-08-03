namespace ProductShop
{
    using System;
    using Data;

    public class Program
    {
        public static void Main()
        {
            using (var context = new ProductShopContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var deserializer = new Deserializer(context);
                deserializer.ImportEntities();

                var serializer = new Serializer(context);

                Console.WriteLine(serializer.ExportProductsInRange());
                Console.WriteLine();
                Console.WriteLine(serializer.ExportSoldProducts());
                Console.WriteLine();
                Console.WriteLine(serializer.ExportCategoriesByProductsCount());
                Console.WriteLine();
                Console.WriteLine(serializer.ExportUsersAndProducts());
            }
        }
    }
}