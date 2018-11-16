namespace Chushka.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Chushka.Models;
    using Contracts;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using ProductType = Chushka.Models.ProductType;

    public class ProductsService : DataService, IProductsService
    {
        public ProductsService(ChushkaDbContext context) : base(context)
        {
        }

        public async Task Create(ProductServiceModel model)
        {
            var product = Mapper.Map<Product>(model);

            await this.context.Products.AddAsync(product);
            await this.context.SaveChangesAsync();
        }

        public async Task<ProductServiceModel> Get(string id)
        {
            var product = await this.context.Products
                .ProjectTo<ProductServiceModel>()
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            return product;
        }

        public async Task Edit(ProductServiceModel model)
        {
            var product = this.context.Products.FirstOrDefault(p => p.Id == model.Id && !p.IsDeleted);

            if (product == null)
            {
                return;
            }

            product.Name = model.Name;
            product.Price = model.Price;
            product.Description = model.Description;
            product.Type = Mapper.Map<ProductType>(model.Type);

            this.context.Products.Update(product);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var product = await this.context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product == null)
            {
                return;
            }

            product.IsDeleted = true;

            this.context.Products.Update(product);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductServiceModel>> GetAll()
        {
            var products = await this.context.Products
                .Where(p => !p.IsDeleted)
                .ProjectTo<ProductServiceModel>()
                .ToArrayAsync();

            return products;
        }
    }
}