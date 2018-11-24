namespace Eventures.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IEventsService
    {
        Task CreateAsync(EventuresEventServiceModel model);

        Task<IEnumerable<EventuresEventServiceModel>> GetAll();
    }
}