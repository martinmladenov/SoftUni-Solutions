namespace ProductShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int? BuyerId { get; set; }

        public User Buyer { get; set; }

        [Required]
        public int SellerId { get; set; }

        public User Seller { get; set; }

        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
