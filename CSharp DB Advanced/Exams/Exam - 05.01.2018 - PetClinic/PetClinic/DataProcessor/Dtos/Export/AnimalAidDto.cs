namespace PetClinic.DataProcessor.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("AnimalAid")]
    public class AnimalAidDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}