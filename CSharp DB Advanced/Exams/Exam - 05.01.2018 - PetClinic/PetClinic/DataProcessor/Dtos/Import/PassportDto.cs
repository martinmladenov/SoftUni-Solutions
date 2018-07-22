namespace PetClinic.DataProcessor.Dtos.Import
{
    using System.ComponentModel.DataAnnotations;

    public class PassportDto
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]{7}\d{3}$")]
        public string SerialNumber { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string OwnerName { get; set; }

        [Required]
        [RegularExpression(@"^(?:\+359|0)\d{9}$")]
        public string OwnerPhoneNumber { get; set; }

        [Required]
        public string RegistrationDate { get; set; }
    }
}