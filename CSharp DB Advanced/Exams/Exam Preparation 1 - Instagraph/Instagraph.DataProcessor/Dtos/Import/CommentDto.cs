namespace Instagraph.DataProcessor.Dtos.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("comment")]
    public class CommentDto
    {
        [Required]
        [MaxLength(250)]
        [XmlElement("content")]
        public string Content { get; set; }

        [Required]
        [MaxLength(30)]
        [XmlElement("user")]
        public string User { get; set; }

        [Required]
        [XmlElement("post")]
        public CommentPostDto Post { get; set; } // commentDto.Post.Id
    }

    public class CommentPostDto
    {
        [Required]
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}