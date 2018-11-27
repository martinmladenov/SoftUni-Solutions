namespace Eventures.Web.Models
{
    using System;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Services.Models;

    public class OrderListingViewModel : IHaveCustomMapping
    {
        public EventListingViewModel Event { get; set; }

        public string UserName { get; set; }

        public DateTime OrderedOn { get; set; }
        
        public int TicketsCount { get; set; }
        
        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<OrderServiceModel, OrderListingViewModel>()
                .ForMember(dest => dest.UserName, opt =>
                    opt.MapFrom(src => src.User.UserName));
        }
    }
}