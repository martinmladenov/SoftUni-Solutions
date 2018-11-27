namespace Eventures.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class EventuresUser : IdentityUser
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string LastName { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string UniqueCitizenNumber { get; set; }
        
        public ICollection<Order> Orders { get; set; }
        
    }
}
