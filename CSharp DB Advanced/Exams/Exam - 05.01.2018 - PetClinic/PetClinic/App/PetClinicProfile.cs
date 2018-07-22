namespace PetClinic.App
{
    using System;
    using System.Globalization;
    using AutoMapper;
    using DataProcessor.Dtos.Import;
    using Models;

    public class PetClinicProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public PetClinicProfile()
        {
            CreateMap<AnimalDto, Animal>();

            CreateMap<PassportDto, Passport>()
                .ForMember(dest => dest.RegistrationDate,
                    opt => opt.MapFrom(src =>
                        DateTime.ParseExact(src.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)));

            CreateMap<VetDto, Vet>();
        }
    }
}
