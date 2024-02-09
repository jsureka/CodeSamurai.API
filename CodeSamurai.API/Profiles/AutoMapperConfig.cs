using AutoMapper;

namespace CodeSamurai.API.Profiles
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Entities.User, Models.UserModel>().ReverseMap();
        }
    }
}
