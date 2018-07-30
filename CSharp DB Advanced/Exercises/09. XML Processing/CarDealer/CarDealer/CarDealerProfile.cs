namespace CarDealer
{
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Dtos.Export;
    using Dtos.Import;

    internal class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierDto, Supplier>();
            CreateMap<Dtos.Import.PartDto, Part>();
            CreateMap<Dtos.Import.CarDto, Car>();
            CreateMap<Dtos.Import.CustomerDto, Customer>();

            CreateMap<Car, CarWithDistanceDto>();
            CreateMap<Car, CarFromFerrariDto>();
            CreateMap<Supplier, LocalSupplierDto>()
                .ForMember(dest => dest.PartsCount,
                    opt => opt.MapFrom(src => src.Parts.Count));
            CreateMap<Part, Dtos.Export.PartDto>();
            CreateMap<Car, Dtos.Export.CarDto>()
                .ForMember(dest => dest.Parts,
                    opt => opt.MapFrom(src => src.PartCars
                        .Select(pc => pc.Part)));
            CreateMap<Car, SoldCarDto>();
            CreateMap<Sale, SaleDto>()
                .ForMember(dest => dest.Price,
                    opt => opt.Ignore())
                .ForMember(dest => dest.CustomerName,
                    opt => opt.MapFrom(src => src.Customer.Name));
        }
    }
}