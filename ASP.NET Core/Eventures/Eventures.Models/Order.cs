namespace Eventures.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public string Id { get; set; }

        [Required]
        public DateTime OrderedOn { get; set; }

        [Required]
        public string EventId { get; set; }

        public EventuresEvent Event { get; set; }

        [Required]
        public string UserId { get; set; }

        public EventuresUser User { get; set; }

        [Required]
        public int TicketsCount { get; set; }
    }
}