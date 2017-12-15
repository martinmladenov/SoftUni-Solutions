using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Comments { get; set; }
    }
}
