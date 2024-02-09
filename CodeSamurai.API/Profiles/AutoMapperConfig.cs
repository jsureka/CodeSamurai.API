using AutoMapper;

namespace CodeSamurai.API.Profiles
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Entities.User, Models.UserModel>().ReverseMap();
            CreateMap<Entities.Station, Models.StationModel>().ReverseMap();
            CreateMap<Entities.Train, Models.TrainModel>().ReverseMap();
        }
    }
}
