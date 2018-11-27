namespace Eventures.Web.Models
{
    using System;
    using Infrastructure.Mapping;
    using Services.Models;

    public class EventListingViewModel : IMapWith<EventuresEventServiceModel>
    {
        public string Id { get; set; }
        
        public string Name { get; set; }

        public string Place { get; set; }

        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
    }
}