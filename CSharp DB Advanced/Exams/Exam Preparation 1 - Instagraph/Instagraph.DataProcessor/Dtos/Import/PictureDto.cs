namespace Instagraph.DataProcessor.Dtos.Import
{
    using System.ComponentModel.DataAnnotations;

    public class PictureDto
    {
        [Required]
        [MinLength(1)]
        public string Path { get; set; }

        [Required]
        public decimal Size { get; set; }
    }
}