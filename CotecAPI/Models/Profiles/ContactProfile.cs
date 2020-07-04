using AutoMapper;
using CotecAPI.Models.DTO;
using CotecAPI.Models.Entities;

namespace CotecAPI.Models.Profiles
{
    public class ContactProfile:Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactUpdateDTO,ContactedPerson>();
            CreateMap<ContactedPerson, ContactUpdateDTO>();
        }
    }
}