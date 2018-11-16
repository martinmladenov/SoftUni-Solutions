namespace Chushka.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Chushka.Models;
    using Contracts;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class OrdersService : DataService, IOrdersService
    {
        public OrdersService(ChushkaDbContext context) : base(context)
        {
        }

        public async Task Create(string productId, string username)
        {
            var product = await this.context.Products.FirstOrDefaultAsync(p => p.Id == productId && !p.IsDeleted);

            var user = await this.context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (product == null || user == null)
            {
                return;
            }

            var order = new Order
            {
                Client = user,
                Product = product,
                OrderedOn = DateTime.Now
            };

            await this.context.Orders.AddAsync(order);

            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderServiceModel>> GetAll()
        {
            var orders = await this.context.Orders
                .ProjectTo<OrderServiceModel>()
                .ToArrayAsync();

            return orders;
        }

    }
}
