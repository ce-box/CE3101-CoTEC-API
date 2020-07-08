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
            CreateMap<SanitaryMeasure, MeasureReadDTO>();
            CreateMap<SanitaryMeasure, MeasureUpdateDTO>();
            CreateMap<MeasureUpdateDTO, SanitaryMeasure>();

            CreateMap<CountrySanitaryMeasures, ImplementedMeasureUpdateDTO>();
            CreateMap<ImplementedMeasureUpdateDTO, CountrySanitaryMeasures>();
            
        }
    }
}