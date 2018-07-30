namespace ProductShop.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("category")]
    public class CategoryDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
