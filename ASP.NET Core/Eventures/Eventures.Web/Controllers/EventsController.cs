namespace Eventures.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Filters;
    using Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models;
    using Services.Contracts;
    using Services.Models;

    public class EventsController : Controller
    {
        private readonly IEventsService eventsService;
        private readonly IOrdersService ordersService;
        private readonly ILogger logger;

        public EventsController(IEventsService eventsService, ILogger<EventsController> logger,
            IOrdersService ordersService)
        {
            this.eventsService = eventsService;
            this.logger = logger;
            this.ordersService = ordersService;
        }

        [Authorize]
        public async Task<IActionResult> All()
        {
            var events = (await this.eventsService.GetAll())
                .Select(Mapper.Map<EventListingViewModel>)
                .ToArray();

            return this.View(events);
        }

        [Authorize(Roles = GlobalConstants.AdminRoleName)]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdminRoleName)]
        [TypeFilter(typeof(AdminCreateLoggerActionFilterAttribute))]
        public async Task<IActionResult> Create(EventCreateBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var serviceModel = Mapper.Map<EventuresEventServiceModel>(model);

            await this.eventsService.CreateAsync(serviceModel);

            this.logger.LogInformation("Event created: " + serviceModel.Name, serviceModel);

            return this.RedirectToAction("All");
        }

        [Authorize]
        public async Task<IActionResult> My()
        {
            var orders = (await this.ordersService
                    .GetAllForUser(this.User.Identity.Name))
                .Select(Mapper.Map<OrderListingViewModel>);

            return this.View(orders);
        }
    }
}