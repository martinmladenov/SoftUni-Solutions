namespace Chushka.Web.Models
{
    using Infrastructure.Mapping;
    using Services.Models;

    public class ProductDetailsViewModel : IMapWith<ProductServiceModel>
    {
        public string Id { get; set; }
        
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }
    }
}
