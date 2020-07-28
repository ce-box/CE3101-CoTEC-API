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
    /// <summary>
    /// This microservice allows to create, modify and eliminate the sanitary measures created for the containment of the CoTEC virus. 
    /// It also allows assigning measures to countries, editing their status (active or inactive) and assigning the start 
    /// and end dates of the measures.
    /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sm"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/v1/measures/new")]
        public ActionResult<MeasureReadDTO> CreateSanitaryMeasure([FromBody] SanitaryMeasure sm)
        {
            _repository.CreateSanitaryMeasure(sm);
            _repository.SaveChanges();

            var measure = _mapper.Map<MeasureReadDTO>(sm);
            return Created("https://cotecapi.com/measures",measure);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/measures/all")]
        public ActionResult<IEnumerable<MeasureReadDTO>> GetAllSanitaryMeasures()
        {
            var measures = _repository.GetMeasures();
            
            return Ok(_mapper.Map<IEnumerable<MeasureReadDTO>>(measures));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CountryCode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/measures/country")]
        public ActionResult<IEnumerable<MeasureView>> GetSanitaryMeasures([FromQuery] string CountryCode)
        {
            var measures = _repository.GetCountrySanitaryMeasures(CountryCode);
            if(measures!= null)
                return Ok(measures);
            return NotFound();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CountryCode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/measures/sanitary")]
        public ActionResult<IEnumerable<MeasureView>> GetActiveSanitaryMeasures([FromQuery] string CountryCode)
        {
            var measures = _repository.GetActiveSanitaryMeasuresByCountry(CountryCode);
            if(measures!= null)
                return Ok(measures);
            return NotFound();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="csm"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/v1/measures/assign")]
        public ActionResult<CountrySanitaryMeasures> AssignSanitaryMeasure([FromBody] CountrySanitaryMeasures csm)
        {
            _repository.AssingSanitaryMeasure(csm);
            _repository.SaveChanges();

            return Created("https://cotecapi.com/measures",csm);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("api/v1/measures/edit")]
        public ActionResult EditMeasure([FromQuery] int Id,JsonPatchDocument<MeasureUpdateDTO> patchDoc)
        {
            // Check if exists
            var measureFromRepo = _repository.GetMeasureById(Id);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Country"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("api/v1/measures/country/edit")]
        public ActionResult EditMeasure([FromQuery] int Id, [FromQuery] string Country ,JsonPatchDocument<ImplementedMeasureUpdateDTO> patchDoc)
        {
            // Check if exists
            var measureFromRepo = _repository.GetSpecificImplementedCountryMeasure(Id,Country);
            if(measureFromRepo == null)
                return NotFound();
            
            var measureToPatch = _mapper.Map<ImplementedMeasureUpdateDTO>(measureFromRepo);
            patchDoc.ApplyTo(measureToPatch, ModelState);

            if (!TryValidateModel(measureToPatch))
                return ValidationProblem(ModelState);
            
            _mapper.Map(measureToPatch, measureFromRepo);

            _repository.UpdateSanitaryMeasure(measureFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Country"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/v1/measures/country/delete")]
        public ActionResult DeleteCountrySanitaryMeasure([FromQuery] int Id, [FromQuery] string Country)
        {
            //TODO: Validations and repo conection
            var measure = _repository.GetSpecificImplementedCountryMeasure(Id, Country);
            if(measure == null)
                return NotFound();
            
            _repository.DeleteCountrySanitaryMeasure(measure);
            _repository.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/v1/measures/delete")]
        public ActionResult DeleteSanitaryMeasure([FromQuery] int id)
        {
            //TODO: Validations and repo conection
            var measure = _repository.GetMeasureById(id);
            if(measure == null)
                return NotFound();
            
            _repository.DeleteSanitaryMeasure(measure);
            _repository.SaveChanges();

            return NoContent();

        }
    }
}