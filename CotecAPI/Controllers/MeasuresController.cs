using System.Collections.Generic;
using AutoMapper;
using CotecAPI.DataAccess.Repositories;
using CotecAPI.Models.DTO;
using CotecAPI.Models.Entities;
using CotecAPI.Models.Views;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CotecAPI.Controllers
{
    [ApiController]
    public class MeasuresController : ControllerBase
    {
        private readonly MeasuresRepo _repository;
        private readonly IMapper _mapper;

        public MeasuresController(MeasuresRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("api/v1/measures/new")]
        public ActionResult<MeasureDTO> CreateSanitaryMeasure([FromBody] SanitaryMeasure sm)
        {
            _repository.CreateSanitaryMeasure(sm);
            _repository.SaveChanges();

            var measure = _mapper.Map<MeasureDTO>(sm);
            return Created("https://cotecapi.com/measures",measure);
        }

        [HttpGet]
        [Route("api/v1/measures/all")]
        public ActionResult<IEnumerable<MeasureDTO>> GetAllSanitaryMeasures()
        {
            var measures = _repository.GetMeasures();
            
            return Ok(_mapper.Map<IEnumerable<MeasureDTO>>(measures));
        }

        [HttpGet]
        [Route("api/v1/measures/country")]
        public ActionResult<IEnumerable<MeasureView>> GetSanitaryMeasures([FromQuery] string CountryCode)
        {
            var measures = _repository.GetSanitaryMeasures(CountryCode);
            if(measures!= null)
                return Ok(measures);
            return NotFound();
        }

        [HttpGet]
        [Route("api/v1/measures/sanitary")]
        public ActionResult<IEnumerable<MeasureView>> GetSanitaryMeasuresv2([FromQuery] string CountryCode)
        {
            var measures = _repository.GetActiveSanitaryMeasures(CountryCode);
            if(measures!= null)
                return Ok(measures);
            return NotFound();
        }

        [HttpPost]
        [Route("api/v1/measures/assign")]
        public ActionResult<CountrySanitaryMeasures> AssignSanitaryMeasure([FromBody] CountrySanitaryMeasures csm)
        {
            _repository.AssingSanitaryMeasure(csm);
            _repository.SaveChanges();

            return Created("https://cotecapi.com/measures",csm);

        }

        [HttpPatch]
        [Route("api/v1/measures/edit")]
        public ActionResult EditMeasure([FromQuery] int Id,JsonPatchDocument<MeasureUpdateDTO> patchDoc)
        {
            // Check if exists
            var measureFromRepo = _repository.GetById(Id);
            if(measureFromRepo == null)
                return NotFound();
            
            var measureToPatch = _mapper.Map<MeasureUpdateDTO>(measureFromRepo);
            patchDoc.ApplyTo(measureToPatch, ModelState);

            if (!TryValidateModel(measureToPatch))
                return ValidationProblem(ModelState);
            
            _mapper.Map(measureToPatch, measureFromRepo);

            _repository.UpdateSanitaryMeasure(measureFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch]
        [Route("api/v1/measures/country/edit")]
        public ActionResult EditMeasure([FromQuery] int Id, [FromQuery] string Country ,JsonPatchDocument<C_MeasureUpdateDTO> patchDoc)
        {
            // Check if exists
            var measureFromRepo = _repository.GetById(Id,Country);
            if(measureFromRepo == null)
                return NotFound();
            
            var measureToPatch = _mapper.Map<C_MeasureUpdateDTO>(measureFromRepo);
            patchDoc.ApplyTo(measureToPatch, ModelState);

            if (!TryValidateModel(measureToPatch))
                return ValidationProblem(ModelState);
            
            _mapper.Map(measureToPatch, measureFromRepo);

            _repository.UpdateSanitaryMeasure(measureFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
        
        [HttpDelete]
        [Route("api/v1/measures/country/delete")]
        public ActionResult DeleteCountrySanitaryMeasure([FromQuery] int Id, [FromQuery] string Country)
        {
            //TODO: Validations and repo conection
            var measure = _repository.GetById(Id, Country);
            if(measure == null)
                return NotFound();
            
            _repository.DeleteCountrySanitaryMeasure(measure);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        [Route("api/v1/measures/delete")]
        public ActionResult DeleteSanitaryMeasure([FromQuery] int id)
        {
            //TODO: Validations and repo conection
            var measure = _repository.GetById(id);
            if(measure == null)
                return NotFound();
            
            _repository.DeleteSanitaryMeasure(measure);
            _repository.SaveChanges();

            return NoContent();

        }
    }
}