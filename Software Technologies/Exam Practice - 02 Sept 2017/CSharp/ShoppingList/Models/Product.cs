using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public int Priority { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
