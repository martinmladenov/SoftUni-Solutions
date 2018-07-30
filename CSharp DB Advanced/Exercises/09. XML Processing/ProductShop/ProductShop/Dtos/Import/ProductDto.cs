namespace ProductShop.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("product")]
    public class ProductDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
