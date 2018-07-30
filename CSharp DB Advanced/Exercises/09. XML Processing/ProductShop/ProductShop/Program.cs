namespace ProductShop
{
    using System;
    using AutoMapper;
    using Data;

    public class Program
    {
        public static void Main()
        {
            Mapper.Initialize(config => config.AddProfile(new ProductShopProfile()));

            using (var context = new ProductShopContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Deserializer deserializer = new Deserializer(context);
                deserializer.ImportEntities();

                Serializer serializer = new Serializer(context);

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
