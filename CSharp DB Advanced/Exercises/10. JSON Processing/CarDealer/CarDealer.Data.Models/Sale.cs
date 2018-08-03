namespace CarDealer.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Sale
    {
        public int Id { get; set; }

        [Required]
        public decimal Discount { get; set; }

        [Required]
        [Column("Car_Id")]
        public int CarId { get; set; }

        public Car Car { get; set; }

        [Required]
        [Column("Customer_Id")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}