namespace Chushka.Models
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class ChushkaUser : IdentityUser
    {
        public string FullName { get; set; }
        
        public ICollection<Order> Orders { get; set; }
    }
}
