namespace Eventures.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Eventures.Models;
    using Infrastructure.Mapping;

    public class OrderServiceModel : IMapWith<Order>
    {
        public string Id { get; set; }

        [Required]
        public DateTime OrderedOn { get; set; }

        public string EventId { get; set; }

        public EventuresEventServiceModel Event { get; set; }

        public string UserId { get; set; }

        public EventuresUserServiceModel User { get; set; }

        [Required]
        public int TicketsCount { get; set; }
    }
}