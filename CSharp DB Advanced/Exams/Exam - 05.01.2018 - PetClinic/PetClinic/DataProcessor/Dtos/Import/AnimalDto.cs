namespace PetClinic.DataProcessor.Dtos.Import
{
    using System.ComponentModel.DataAnnotations;

    public class AnimalDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Type { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Age { get; set; }

        [Required]
        public PassportDto Passport { get; set; }
    }
}
