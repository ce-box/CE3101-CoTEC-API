using System.Collections.Generic;
using CotecAPI.DataAccess.Repositories;
using CotecAPI.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace CotecAPI.Controllers
{
    [ApiController]
    public class CasesController: ControllerBase
    {
        private readonly CasesRepo _repository;

        public CasesController(CasesRepo repository)
        {
            _repository = repository;
        }

        /* -------------------------------------------
                       CASE REPORT SERVISES 
           -------------------------------------------*/

        [HttpGet]
        [Route("api/v1/cases/world")]
        public ActionResult<CasesView> GetWorldCases() 
        {
            var worldCases = _repository.GetWorldCases();
            if (worldCases != null)
                return Ok(worldCases);

            return NotFound();
        }

        [HttpGet]
        [Route("api/v1/cases/country")]
        public ActionResult<CasesView> GetCasesByCountry([FromQuery] string code) 
        {
            var countryItem = _repository.GetByCode(code);
            if (countryItem != null)
                return Ok(countryItem);

            return NotFound();
        }

        [HttpGet]
        [Route("api/v1/cases/country/all")]
        public ActionResult<IEnumerable<CasesView>> GetAllCountriesCases() 
        {
            var countryItems = _repository.GetAll();
            if (countryItems != null)
                return Ok(countryItems);

            return NotFound();
        }
    }
}