using AutoMapper;
using CotecAPI.Models.DTO;
using CotecAPI.Models.Entities;

namespace CotecAPI.Models.Profiles
{
    public class HospitalProfile : Profile
    {
        public HospitalProfile()
        {
            // Source -> Target
            CreateMap<Hospital, HospitalReadDTO>();
            CreateMap<Hospital, HospitalUpdateDTO>();
            CreateMap<HospitalUpdateDTO, Hospital>();
        }
    }
}