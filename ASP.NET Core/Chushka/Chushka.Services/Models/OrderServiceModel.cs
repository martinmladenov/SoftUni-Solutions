namespace Chushka.Services.Models
{
    using System;
    using Chushka.Models;
    using Infrastructure.Mapping;

    public class OrderServiceModel : IMapWith<Order>
    {
        public string Id { get; set; }

        public string ProductId { get; set; }

        public ProductServiceModel Product { get; set; }

        public string ClientId { get; set; }

        public ChushkaUserServiceModel Client { get; set; }

        public DateTime OrderedOn { get; set; }
    }
}
