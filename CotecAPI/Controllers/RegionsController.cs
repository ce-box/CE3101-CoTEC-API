using System.Collections.Generic;
using CotecAPI.DataAccess.Repositories;
using CotecAPI.Models.Views;
using CotecAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using CotecAPI.Models.DTO;
using AutoMapper;
using System;

namespace CotecAPI.Controllers
{
    [ApiController]
    public class RegionsController: ControllerBase
    {
        private readonly RegionRepo _repository;
        private readonly IMapper _mapper;

        public RegionsController(RegionRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/v1/regions/country")]
        public ActionResult<IEnumerable<RegionReadDTO>> GetRegions([FromQuery] string CountryCode)
        {
            var regions = _repository.GetRegions(CountryCode);
            return Ok(_mapper.Map<IEnumerable<RegionReadDTO>>(regions));
        }

        [HttpGet]
        [Route("api/v1/countries/all")]
        public ActionResult<IEnumerable<CountryDTO>> GetCountryList()
        {
            var countryList = _repository.GetCountries();
            return Ok(_mapper.Map<IEnumerable<CountryDTO>>(countryList));
        }

        [HttpPost]
        [Route("api/v1/regions/new")]
        public ActionResult<RegionReadDTO> CreateRegion([FromBody] Region reg)
        {
            var countryFromRepo = _repository.Exist(reg.Name, reg.CountryCode);
            if(countryFromRepo != null)
                return new BadRequestObjectResult(new { message = "Existing Region", currentDate = DateTime.Now });

            _repository.CreateRegion(reg);
             _repository.SaveChanges();
            
            var region = _mapper.Map<RegionReadDTO>(reg);
            return Created("https://cotecapi.com/regions",region);
        }

        [HttpDelete]
        [Route("api/v1/regions/delete")]
        public ActionResult DeleteRegion([FromQuery] string Name,[FromQuery] string Country)
        {
            var region = _repository.Exist(Name, Country);
            if(region == null)
                return NotFound();

            _repository.DeleteRegion(region);
            _repository.SaveChanges();

            return NoContent();
        }
        
    }
}