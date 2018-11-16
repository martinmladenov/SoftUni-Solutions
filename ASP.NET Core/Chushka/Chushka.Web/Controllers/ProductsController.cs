namespace Chushka.Web.Controllers
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Chushka.Models;
    using Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services.Contracts;
    using Services.Models;

    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            var product = await this.productsService.Get(id);

            if (product == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            var viewModel = Mapper.Map<ProductDetailsViewModel>(product);

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdminRoleName)]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdminRoleName)]
        public async Task<IActionResult> Create(ProductEditViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }
            
            ProductServiceModel product = new ProductServiceModel()
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Type = Enum.Parse<ProductType>(model.Type)
            };

            await this.productsService.Create(product);

            return this.RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = GlobalConstants.AdminRoleName)]
        public async Task<IActionResult> Edit(string id)
        {
            var product = await this.productsService.Get(id);

            if (product == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            var viewModel = Mapper.Map<ProductEditViewModel>(product);

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdminRoleName)]
        public async Task<IActionResult> Edit(ProductEditViewModel model, string id)
        {
            var serviceModel = Mapper.Map<ProductServiceModel>(model);

            serviceModel.Id = id;
            
            await this.productsService.Edit(serviceModel);

            return this.RedirectToAction("Details", "Products", id);
        }

        [Authorize(Roles = GlobalConstants.AdminRoleName)]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await this.productsService.Get(id);

            if (product == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            var viewModel = Mapper.Map<ProductEditViewModel>(product);

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdminRoleName)]
        public async Task<IActionResult> Delete(ProductEditViewModel model, string id)
        {
            await this.productsService.Delete(id);

            return this.RedirectToAction("Index", "Home");
        }
    }
}