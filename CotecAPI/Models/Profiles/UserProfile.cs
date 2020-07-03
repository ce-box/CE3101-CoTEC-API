using AutoMapper;
using CotecAPI.Models.DTO;
using CotecAPI.Models.Entities;

namespace CotecAPI.Models.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserLoginDTO,Admin>();
            CreateMap<UserLoginDTO,Admin>();
            
            CreateMap<Admin, AdminReadDTO>();
            CreateMap<HospitalEmployee, HEmployeeReadDTO>();
        }
    }
}