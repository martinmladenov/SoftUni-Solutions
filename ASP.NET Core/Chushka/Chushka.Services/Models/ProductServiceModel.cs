namespace Chushka.Services.Models
{
    using System.Collections.Generic;
    using Chushka.Models;
    using Infrastructure.Mapping;

    public class ProductServiceModel : IMapWith<Product>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public ProductType Type { get; set; }

        public ICollection<OrderServiceModel> Orders { get; set; }

        public bool IsDeleted { get; set; }
    }
}
