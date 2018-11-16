namespace Chushka.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IProductsService
    {
        Task Create(ProductServiceModel model);

        Task<ProductServiceModel> Get(string id);

        Task Edit(ProductServiceModel model);

        Task Delete(string id);

        Task<IEnumerable<ProductServiceModel>> GetAll();
    }
}