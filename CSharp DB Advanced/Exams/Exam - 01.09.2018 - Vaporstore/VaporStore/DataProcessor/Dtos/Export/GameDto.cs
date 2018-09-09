namespace VaporStore.DataProcessor.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("Game")]
    public class GameDto
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }
    }
}