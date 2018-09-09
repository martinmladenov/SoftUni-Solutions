namespace VaporStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Purchase
    {
        public int Id { get; set; }

        [Required] 
        public PurchaseType Type { get; set; }

        [Required]
        [RegularExpression("^([A-Z0-9]{4}-){2}[A-Z0-9]{4}$")]
        public string ProductKey { get; set; }

        [Required] 
        public DateTime Date { get; set; }

        [Required]
        public int CardId { get; set; }

        public Card Card { get; set; }

        [Required]
        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}