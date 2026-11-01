using DAL.EF;
using BLL.DTO;
using AutoMapper;

namespace BLL.Profiles
{
    public class MovieProfiles : Profile
    {
        public MovieProfiles()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
        }
    }
}
