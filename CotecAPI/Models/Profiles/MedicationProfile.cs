using AutoMapper;
using CotecAPI.Models.DTO;
using CotecAPI.Models.Entities;

namespace CotecAPI.Models.Profiles
{
    public class MedicationProfile : Profile
    {
        public MedicationProfile()
        {
            // Source -> Target
            CreateMap<PharmaceuticalCompany, PharmCoDTO>();
            CreateMap<Medication, MedicationDTO>();
            CreateMap<Medication, MedicationUpdateDTO>();
            CreateMap<MedicationUpdateDTO, Medication>();
        }        
    }
}