namespace Instagraph.DataProcessor.Dtos.Import
{
    using System.ComponentModel.DataAnnotations;

    public class UserFollowerDto
    {
        [Required]
        [MaxLength(30)]
        public string User { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Follower { get; set; }
    }
}