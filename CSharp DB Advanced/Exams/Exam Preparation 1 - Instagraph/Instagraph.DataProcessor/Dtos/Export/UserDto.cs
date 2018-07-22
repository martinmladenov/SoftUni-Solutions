namespace Instagraph.DataProcessor.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("user")]
    public class UserDto
    {
        public string Username { get; set; }

        public int MostComments { get; set; }
    }
}