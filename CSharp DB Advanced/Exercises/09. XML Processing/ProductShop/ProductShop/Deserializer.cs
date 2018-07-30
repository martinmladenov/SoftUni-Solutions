namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Dtos.Import;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;

    public class Deserializer
    {
        private ProductShopContext context;

        public Deserializer(ProductShopContext context)
        {
            this.context = context;
        }

        public void ImportEntities()
        {
            ImportUsers();
            ImportCategories();
            ImportProducts();
        }

        private void ImportUsers()
        {
            var serializer = new XmlSerializer(typeof(UserDto[]),
                new XmlRootAttribute("users"));

            var deserializedUsers = (UserDto[])serializer.Deserialize(
                new MemoryStream(File.ReadAllBytes("../../../Datasets/users.xml")));

            var users = deserializedUsers.AsQueryable().ProjectTo<User>().ToArray();

            context.Users.AddRange(users);

            context.SaveChanges();

            Console.WriteLine("Imported users.xml");
        }

        private void ImportCategories()
        {
            var serializer = new XmlSerializer(typeof(CategoryDto[]),
                new XmlRootAttribute("categories"));

            var deserializedCategories = (CategoryDto[])serializer.Deserialize(
                new MemoryStream(File.ReadAllBytes("../../../Datasets/categories.xml")));

            var categories = deserializedCategories.AsQueryable().ProjectTo<Category>().ToArray();

            context.Categories.AddRange(categories);

            context.SaveChanges();

            Console.WriteLine("Imported categories.xml");
        }

        private void ImportProducts()
        {
            var serializer = new XmlSerializer(typeof(ProductDto[]),
                new XmlRootAttribute("products"));

            var deserializedProducts = (ProductDto[])serializer.Deserialize(
                new MemoryStream(File.ReadAllBytes("../../../Datasets/products.xml")));

            var products = deserializedProducts.AsQueryable().ProjectTo<Product>().ToArray();

            Random random = new Random();


            User[] allUsers = context.Users.ToArray();
            User GetRandomUser() => allUsers[random.Next(allUsers.Length)];

            Category[] allCategories = context.Categories.ToArray();
            Category GetRandomCategory() => allCategories[random.Next(allCategories.Length)];


            foreach (var product in products)
            {
                product.Seller = GetRandomUser();

                int categoriesCount = random.Next(1, 6);

                product.CategoryProducts = new List<CategoryProduct>();

                var addedCategories = new HashSet<Category>();

                for (int i = 0; i < categoriesCount; i++)
                {
                    var category = GetRandomCategory();

                    if (addedCategories.Contains(category)) continue;

                    product.CategoryProducts.Add(new CategoryProduct
                    {
                        Category = category
                    });

                    addedCategories.Add(category);
                }

                if (random.Next(3) == 0)
                {
                    product.Buyer = GetRandomUser();
                }
            }

            context.Products.AddRange(products);

            context.SaveChanges();

            Console.WriteLine("Imported products.xml");
        }
    }
}
