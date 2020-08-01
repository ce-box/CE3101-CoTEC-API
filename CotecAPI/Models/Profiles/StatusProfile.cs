using AutoMapper;
using CotecAPI.Models.DTO;
using CotecAPI.Models.Entities;

namespace CotecAPI.Models.Profiles
{
    public class StatusProfile : Profile
    {
        public StatusProfile()
        {
            // Source -> Target
            CreateMap<PatientStatus, StatusReadDTO>();
            CreateMap<PatientStatus, StatusUpdateDTO>();
            CreateMap<StatusUpdateDTO, PatientStatus>();
        }
    }
}