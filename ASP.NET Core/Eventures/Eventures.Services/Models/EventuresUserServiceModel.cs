namespace Eventures.Services.Models
{
    using System.ComponentModel.DataAnnotations;
    using Eventures.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNetCore.Identity;

    public class EventuresUserServiceModel : IdentityUser, IMapWith<EventuresUser>
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string LastName { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string UniqueCitizenNumber { get; set; }
        
    }
}
