namespace Eventures.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Eventures.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class OrdersService : DataService, IOrdersService
    {
        public OrdersService(EventuresDbContext context) : base(context)
        {
        }

        public async Task<bool> Create(OrderServiceModel model, string userName)
        {
            if (!this.IsEntityStateValid(model))
            {
                return false;
            }

            var user = await this.context.Users.SingleOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
            {
                return false;
            }

            var order = Mapper.Map<Order>(model);

            order.User = user;

            await this.context.Orders.AddAsync(order);

            await this.context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<OrderServiceModel>> GetAll()
        {
            var orders = await this.context.Orders
                .ProjectTo<OrderServiceModel>()
                .ToArrayAsync();

            return orders;
        }

        public async Task<IEnumerable<OrderServiceModel>> GetAllForUser(string userName)
        {
            var user = await this.context.Users.SingleOrDefaultAsync(u => u.UserName == userName);

            if (user == null)
            {
                return null;
            }

            var orders = await this.context.Orders
                .Where(o => o.UserId == user.Id)
                .ProjectTo<OrderServiceModel>()
                .ToArrayAsync();

            return orders;
        }
    }
}