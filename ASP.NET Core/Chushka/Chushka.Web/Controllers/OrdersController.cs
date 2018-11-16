namespace Chushka.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services.Contracts;

    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        [Authorize]
        public async Task<IActionResult> Create(string id)
        {
            await this.ordersService.Create(id, this.User.Identity.Name);

            return this.RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = GlobalConstants.AdminRoleName)]
        public async Task<IActionResult> All()
        {
            var orders = (await this.ordersService.GetAll())
                .Select(Mapper.Map<OrderListViewModel>)
                .ToArray();

            return this.View(orders);
        }
    }
}