namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("product")]
    public class ProductInRangeDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [XmlAttribute("buyer")]
        public string Buyer { get; set; }
    }
}
