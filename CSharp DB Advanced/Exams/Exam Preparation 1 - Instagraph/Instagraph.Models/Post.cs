namespace Instagraph.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Caption { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int PictureId { get; set; }

        public Picture Picture { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}