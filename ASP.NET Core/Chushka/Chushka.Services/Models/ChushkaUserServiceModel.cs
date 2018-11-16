namespace Chushka.Services.Models
{
    using System.Collections.Generic;
    using Chushka.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNetCore.Identity;

    public class ChushkaUserServiceModel : IdentityUser, IMapWith<ChushkaUser>
    {
        public string FullName { get; set; }
        
        public ICollection<OrderServiceModel> Orders { get; set; }
    }
}
