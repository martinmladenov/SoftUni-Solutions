namespace VaporStore.DataProcessor.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("User")]
    public class UserDto
    {
        [XmlAttribute("username")]
        public string Username { get; set; }

        public PurchaseDto[] Purchases { get; set; }

        public decimal TotalSpent { get; set; }
    }
}