namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("user")]
    public class UserWithProductsDto
    {
        [XmlAttribute("first-name")]
        public string FirstName { get; set; }

        [XmlAttribute("last-name")]
        public string LastName { get; set; }

        [XmlElement("sold-products")]
        public SoldProductDto[] SoldProducts { get; set; }
    }
}
