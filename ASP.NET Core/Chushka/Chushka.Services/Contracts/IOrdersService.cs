namespace Chushka.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IOrdersService
    {
        Task Create(string productId, string username);

        Task<IEnumerable<OrderServiceModel>> GetAll();
    }
}