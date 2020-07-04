using AutoMapper;
using CotecAPI.Models.DTO;
using CotecAPI.Models.Entities;

namespace CotecAPI.Models.Profiles
{
    public class MeasuresProfile : Profile
    {
        public MeasuresProfile()
        {
            // Source -> Target
            CreateMap<SanitaryMeasure, MeasureDTO>();
            CreateMap<SanitaryMeasure, MeasureUpdateDTO>();
            CreateMap<MeasureUpdateDTO, SanitaryMeasure>();

            CreateMap<CountrySanitaryMeasures, C_MeasureUpdateDTO>();
            CreateMap<C_MeasureUpdateDTO, CountrySanitaryMeasures>();
            
        }
    }
}