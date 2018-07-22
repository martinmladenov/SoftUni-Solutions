namespace PetClinic.DataProcessor.Dtos.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Procedure")]
    public class ProcedureDto
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Vet { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]{7}\d{3}$")]
        public string Animal { get; set; }

        [Required]
        public string DateTime { get; set; }

        [Required]
        public AnimalAidDto[] AnimalAids { get; set; }
    }
}
