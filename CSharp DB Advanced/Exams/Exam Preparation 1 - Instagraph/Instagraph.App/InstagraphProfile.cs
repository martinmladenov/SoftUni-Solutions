using AutoMapper;

namespace Instagraph.App
{
    using DataProcessor.Dtos.Import;
    using Models;

    public class InstagraphProfile : Profile
    {
        public InstagraphProfile()
        {
            CreateMap<PictureDto, Picture>();

            CreateMap<UserDto, User>()
                .ForMember(u => u.ProfilePicture,
                    opt => opt.Ignore());
        }
    }
}
