namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Data;
    using Data.Models;
    using Dtos;
    using Newtonsoft.Json;

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
            var deserializedUsers =
                JsonConvert.DeserializeObject<UserDto[]>(File.ReadAllText("../../../Datasets/users.json"));

            var users = deserializedUsers
                .Select(u => new User
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age != null
                        ? int.Parse(u.Age)
                        : (int?) null
                })
                .ToArray();

            context.Users.AddRange(users);

            context.SaveChanges();

            Console.WriteLine("Imported users.json");
        }

        private void ImportCategories()
        {
            var categories =
                JsonConvert.DeserializeObject<Category[]>(File.ReadAllText("../../../Datasets/categories.json"));

            context.Categories.AddRange(categories);

            context.SaveChanges();

            Console.WriteLine("Imported categories.json");
        }

        private void ImportProducts()
        {
            var products =
                JsonConvert.DeserializeObject<Product[]>(File.ReadAllText("../../../Datasets/products.json"));

            var random = new Random();

            var allUsers = context.Users.ToArray();

            User GetRandomUser()
            {
                return allUsers[random.Next(allUsers.Length)];
            }

            var allCategories = context.Categories.ToArray();

            Category GetRandomCategory()
            {
                return allCategories[random.Next(allCategories.Length)];
            }


            foreach (var product in products)
            {
                product.Seller = GetRandomUser();

                var categoriesCount = random.Next(1, 6);

                product.CategoryProducts = new List<CategoryProduct>();

                var addedCategories = new HashSet<Category>();

                for (var i = 0; i < categoriesCount; i++)
                {
                    var category = GetRandomCategory();

                    if (addedCategories.Contains(category)) continue;

                    product.CategoryProducts.Add(new CategoryProduct
                    {
                        Category = category
                    });

                    addedCategories.Add(category);
                }

                if (random.Next(3) == 0) product.Buyer = GetRandomUser();
            }

            context.Products.AddRange(products);

            context.SaveChanges();

            Console.WriteLine("Imported products.json");
        }
    }
}