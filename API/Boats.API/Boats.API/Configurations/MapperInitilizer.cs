using AutoMapper;
using Boats.API.Data;
using Boats.API.Models;

namespace Boats.API.Configurations
{
    public class MapperInitilizer:Profile
    {
        public MapperInitilizer()
        {
            CreateMap<Boat, BoatDTO>().ReverseMap();
            CreateMap<Boat, CreateBoatDTO>().ReverseMap();
            CreateMap<ApiUser, UserDTO>().ReverseMap();
        }
    }
}
