using AutoMapper;

namespace ProductShop
{
    using Data.Models;
    using Dtos.Export;
    using Dtos.Import;
    using CategoryDto = Dtos.Import.CategoryDto;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Age,
                    opt => opt.MapFrom(src =>
                        src.Age != null
                        ? int.Parse(src.Age)
                        : (int?)null));
            CreateMap<CategoryDto, Category>();
            CreateMap<ProductDto, Product>();

            CreateMap<Product, SoldProductDto>();
        }
    }
}