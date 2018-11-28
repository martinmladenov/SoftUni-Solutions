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

    public class EventsService : DataService, IEventsService
    {
        public EventsService(EventuresDbContext context) : base(context)
        {
        }

        public async Task CreateAsync(EventuresEventServiceModel model)
        {
            if (!this.IsEntityStateValid(model))
            {
                return;
            }

            var ev = Mapper.Map<EventuresEvent>(model);

            await this.context.AddAsync(ev);

            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventuresEventServiceModel>> GetAll()
        {
            return await this.context.Events
                .Where(e => e.TotalTickets > 0)
                .ProjectTo<EventuresEventServiceModel>()
                .ToArrayAsync();
        }
    }
}