namespace P01_StudentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Column("varchar(max)")]
        [Required]
        public string Url { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }

    public enum ResourceType
    {
        Video,
        Presentation,
        Document,
        Other
    }
}
