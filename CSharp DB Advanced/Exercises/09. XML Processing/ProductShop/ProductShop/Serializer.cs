namespace ProductShop
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Dtos.Export;
    using Microsoft.EntityFrameworkCore;

    public class Serializer
    {
        private ProductShopContext context;

        public Serializer(ProductShopContext context)
        {
            this.context = context;
        }

        public string ExportProductsInRange()
        {
            var products = context.Products
                .Include(p => p.Buyer)
                .Where(p => p.Price >= 1000 && p.Price <= 2000
                                            && p.Buyer != null)
                .OrderBy(p => p.Price)
                .ToArray();

            var productDtos = new ProductInRangeDto[products.Length];

            for (var i = 0; i < products.Length; i++)
            {
                var product = products[i];
                string buyer = $"{product.Buyer.FirstName} {product.Buyer.LastName}"
                    .Trim();

                productDtos[i] = new ProductInRangeDto()
                {
                    Name = product.Name,
                    Price = product.Price,
                    Buyer = buyer
                };
            }

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(productDtos.GetType(), new XmlRootAttribute("products"));

            serializer.Serialize(new StringWriter(sb), productDtos, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            return sb.ToString();
        }

        public string ExportSoldProducts()
        {
            var users = context.Users
                .Include(u => u.ProductsSold)
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToArray();

            var userDtos = new UserWithProductsDto[users.Length];

            for (var i = 0; i < users.Length; i++)
            {
                var user = users[i];

                var soldProducts = user.ProductsSold
                    .AsQueryable()
                    .ProjectTo<SoldProductDto>()
                    .ToArray();

                userDtos[i] = new UserWithProductsDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    SoldProducts = soldProducts
                };
            }

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(userDtos.GetType(), new XmlRootAttribute("users"));

            serializer.Serialize(new StringWriter(sb), userDtos, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            return sb.ToString();
        }

        public string ExportCategoriesByProductsCount()
        {
            var categories = context.Categories
                .Include(c => c.CategoryProducts)
                .ThenInclude(cp => cp.Product)
                .OrderByDescending(c => c.CategoryProducts.Count)
                .ToArray();

            var categoryDtos = new CategoryDto[categories.Length];

            for (var i = 0; i < categories.Length; i++)
            {
                var category = categories[i];

                categoryDtos[i] = new CategoryDto
                {
                    Name = category.Name,
                    ProductsCount = category.CategoryProducts.Count,
                    AveragePrice = category.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = category.CategoryProducts.Sum(cp => cp.Product.Price)
                };
            }

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(categoryDtos.GetType(), new XmlRootAttribute("categories"));

            serializer.Serialize(new StringWriter(sb), categoryDtos, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            return sb.ToString();
        }

        public string ExportUsersAndProducts()
        {
            var users = context.Users
                .Include(u => u.ProductsSold)
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count)
                .ThenBy(u => u.LastName)
                .ToArray();

            var root = new XElement("users", new XAttribute("count", users.Length));

            foreach (var user in users)
            {
                var userElement = new XElement("user");

                if (user.FirstName != null)
                {
                    userElement.Add(new XAttribute("first-name", user.FirstName));
                }

                userElement.Add(new XAttribute("last-name", user.LastName));

                if (user.Age != null)
                {
                    userElement.Add(new XAttribute("age", user.Age));
                }

                var productsElement = new XElement("sold-products",
                    new XAttribute("count", user.ProductsSold.Count));

                foreach (var product in user.ProductsSold)
                {
                    productsElement.Add(new XElement("product",
                        new XAttribute("name", product.Name),
                        new XAttribute("price", product.Price)));
                }

                userElement.Add(productsElement);

                root.Add(userElement);
            }

            XDocument xml = new XDocument(root);

            return xml.ToString();
        }
    }
}
