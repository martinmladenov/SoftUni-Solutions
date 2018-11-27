namespace Eventures.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mapping;
    using Services.Models;

    public class OrderCreateBindingModel : IMapWith<OrderServiceModel>
    {
        [Required]
        public string EventId { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Tickets")]
        public int TicketsCount { get; set; }
    }
}