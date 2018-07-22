namespace PetClinic.DataProcessor.Dtos.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("AnimalAid")]
    public class AnimalAidDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
    }
}