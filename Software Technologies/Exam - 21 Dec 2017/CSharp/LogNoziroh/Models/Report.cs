using System.ComponentModel.DataAnnotations;

namespace LogNoziroh.Models
{
    public class Report
    {
        public int Id { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string Origin { get; set; }


    }
}