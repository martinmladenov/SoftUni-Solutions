namespace Eventures.Web.Models
{
    using Infrastructure.Mapping;
    using Services.Models;

    public class UserListingViewModel : IMapWith<EventuresUserServiceModel>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UniqueCitizenNumber { get; set; }

        public bool IsAdmin { get; set; }
    }
}