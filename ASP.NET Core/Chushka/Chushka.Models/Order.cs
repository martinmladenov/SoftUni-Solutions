namespace Chushka.Models
{
    using System;

    public class Order
    {
        public string Id { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }

        public string ClientId { get; set; }

        public ChushkaUser Client { get; set; }

        public DateTime OrderedOn { get; set; }
    }
}
