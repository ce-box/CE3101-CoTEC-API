using AutoMapper;
using CotecAPI.Models.DTO;
using CotecAPI.Models.Entities;

namespace CotecAPI.Models.Profiles
{
    public class PathologyProfile : Profile
    {
        public PathologyProfile()
        {
            // Source -> Target
            CreateMap<Pathology, PathologyReadDTO>();
            CreateMap<Pathology, PathologyUpdateDTO>();
            CreateMap<PathologyUpdateDTO, Pathology>();
        }
        
    }
}