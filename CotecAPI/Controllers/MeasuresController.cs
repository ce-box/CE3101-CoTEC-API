using System.Collections.Generic;
using CotecAPI.DataAccess.Repositories;
using CotecAPI.Models.Entities;
using CotecAPI.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace CotecAPI.Controllers
{
    [ApiController]
    public class MeasuresController : ControllerBase
    {
        private readonly MeasuresRepo _repository;

        public MeasuresController(MeasuresRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/v1/measures/sanitary")]
        public ActionResult<IEnumerable<MeasureView>> GetSanitaryMeasures([FromQuery] string CountryCode)
        {
            var measures = _repository.GetSanitaryMeasures(CountryCode);
            if(measures!= null)
                return Ok(measures);
            return NotFound();
        }

        [HttpGet]
        [Route("api/v1/measures/containment")]
        public ActionResult<IEnumerable<MeasureView>> GetContainmentMeasures([FromQuery] string CountryCode)
        {
            var measures = _repository.GetContainmentMeasures(CountryCode);
            if(measures!= null)
                return Ok(measures);
            return NotFound();
        }

        [HttpPost]
        [Route("api/v1/measures/sanitary/new")]
        public ActionResult<SanitaryMeasure> CreateSanitaryMeasure([FromBody] SanitaryMeasure sm)
        {
            _repository.CreateSanitaryMeasure(sm);
            _repository.SaveChanges();

            return Created("https://cotecapi.com/measures",sm);

        }

        [HttpPost]
        [Route("api/v1/measures/containment/new")]
        public ActionResult<SanitaryMeasure> CreateContainmentMeasure([FromBody] ContainmentMeasure cm)
        {
            _repository.CreateContainmentMeasure(cm);
            _repository.SaveChanges();

            return Created("https://cotecapi.com/measures",cm);

        }

        [HttpPost]
        [Route("api/v1/measures/sanitary/assign")]
        public ActionResult<SanitaryMeasure> AssignSanitaryMeasure([FromBody] CountrySanitaryMeasures csm)
        {
            _repository.AssingSanitaryMeasure(csm);
            _repository.SaveChanges();

            return Created("https://cotecapi.com/measures",csm);

        }

        [HttpPost]
        [Route("api/v1/measures/sanitary/assign")]
        public ActionResult<SanitaryMeasure> AssignContainmentMeasure([FromBody] CountryContainmentMeasures ccm)
        {
            _repository.AssingContainmentMeasure(ccm);
            _repository.SaveChanges();

            return Created("https://cotecapi.com/measures",ccm);

        }
        

        [HttpDelete]
        [Route("api/v1/measures/sanitary")]
        public ActionResult DeleteSanitaryMeasure(int id)
        {
            //TODO: Validations and repo conection

            return NoContent();

        }

        [HttpDelete]
        [Route("api/v1/measures/containment")]
        public ActionResult DeleteContainmentMeasure(int id)
        {
            //TODO: Validations and repo conection

            return NoContent();

        }




    }
}