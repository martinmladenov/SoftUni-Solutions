namespace Eventures.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IOrdersService
    {
        Task<bool> Create(OrderServiceModel model, string userName);
        Task<IEnumerable<OrderServiceModel>> GetAll();
        Task<IEnumerable<OrderServiceModel>> GetAllForUser(string userName);
    }
}