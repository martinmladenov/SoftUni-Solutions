namespace VaporStore.DataProcessor.Dtos.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Purchase")]
    public class PurchaseDto
    {
        [Required]
        [XmlAttribute("title")]
        public string Title { get; set; }
        
        [Required] 
        public string Type { get; set; }
        
        [Required]
        [RegularExpression("^([A-Z0-9]{4}-){2}[A-Z0-9]{4}$")]
        public string Key { get; set; }
        
        [Required]
        [RegularExpression(@"^(\d{4} ){3}\d{4}$")]
        public string Card { get; set; }
        
        [Required]
        public string Date { get; set; }
    }
}