namespace VaporStore.DataProcessor.Dtos.Import
{
    using System.ComponentModel.DataAnnotations;

    public class UserDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [RegularExpression("^[A-Z][a-zA-Z]* [A-Z][a-zA-Z]*$")]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Range(3, 103)]
        public int Age { get; set; }
        
        [Required]
        public CardDto[] Cards { get; set; }
    }

    public class CardDto
    {
        [Required]
        [RegularExpression(@"^(\d{4} ){3}\d{4}$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}$")]
        public string Cvc { get; set; }

        [Required]
        public string Type { get; set; }
    }
}