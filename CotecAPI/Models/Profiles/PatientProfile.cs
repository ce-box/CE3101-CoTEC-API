using AutoMapper;
using CotecAPI.Models.DTO;
using CotecAPI.Models.DTO.Patient;
using CotecAPI.Models.Entities;

namespace CotecAPI.Models.Profiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            // Source -> Target
            CreateMap<Patient, PatientReadDTO>();
            CreateMap<PatientUpdateDTO, Patient>();
            CreateMap<Patient, PatientUpdateDTO >();
        }
    }
}