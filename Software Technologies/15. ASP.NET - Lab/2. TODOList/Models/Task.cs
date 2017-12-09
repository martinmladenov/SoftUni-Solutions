using System.ComponentModel.DataAnnotations;

namespace _2.TODOList.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
