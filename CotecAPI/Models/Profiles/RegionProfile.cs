using AutoMapper;
using CotecAPI.Models.DTO;
using CotecAPI.Models.Entities;

namespace CotecAPI.Models.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            // Source -> Target
            CreateMap<Region, RegionReadDTO>();
            CreateMap<RegionReadDTO, Region>();
            CreateMap<Country, CountryReadDTO>();
        }
    }
}