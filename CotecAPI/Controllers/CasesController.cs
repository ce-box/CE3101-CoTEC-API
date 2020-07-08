using System.Collections.Generic;
using CotecAPI.DataAccess.Repositories;
using CotecAPI.Models.Entities;
using CotecAPI.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace CotecAPI.Controllers
{
    /// <summary>
    /// This Service Allows the client to request the information of the CoTEC 20 
    /// cases registered in a specific country, in a report of each country or globally.
    /// </summary>
    [ApiController]
    public class CasesController: ControllerBase
    {
        private readonly CasesRepo _repository;

        public CasesController(CasesRepo repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// Generates a report of all the infected, recovered, dead, active and the increase of the day, worldwide.
        /// </summary>
        /// <returns>JSON with infected, recovered, dead, active cases and daily increment.</returns>
        /// GET: api/v1/cases/world
        [HttpGet]
        [Route("api/v1/cases/world")]
        public ActionResult<CasesView> GetWorldCases() 
        {
            var worldCases = _repository.GetWorldCases();
            if (worldCases != null)
                return Ok(worldCases);

            return NotFound();
        }

        /// <summary>
        /// Gives a report of the cases of a country. 
        /// Total infected, Recovered, Dead and Active, together with the daily increase.
        /// </summary>
        /// <param name="CountryCode">Country code in alpha-3 format (ISO 3166).</param>
        /// <returns>JSON with infected, recovered, dead, active cases and daily increment.</returns>
        /// GET: api/v1/cases/country?code=ABC
        [HttpGet]
        [Route("api/v1/cases/country")]
        public ActionResult<CasesView> GetCasesByCountry([FromQuery] string CountryCode) 
        {
            var countryItem = _repository.GetCountryCases(CountryCode);
            if (countryItem != null)
                return Ok(countryItem);

            return NotFound();
        }

        /// <summary>
        /// Gives a report of the cases of a country. 
        /// Total infected, Recovered, Dead and Active, together with the daily increase.
        /// </summary>
        /// <returns>JSON with infected, recovered, dead, active cases and daily increment.</returns>
        /// GET: api/v1/cases/country/all
        [HttpGet]
        [Route("api/v1/cases/country/all")]
        public ActionResult<IEnumerable<CasesView>> GetAllCountriesCases() 
        {
            var countryItems = _repository.GetAllCountriesReport();
            if (countryItems != null)
                return Ok(countryItems);

            return NotFound();
        }

        /// <summary>
        /// In this report we want to obtain only the new cases and deaths of the day and 7 days ago of each country.
        /// </summary>
        /// <returns>JSON with a list of countries, and in each country comes a breakdown of the date 
        /// and new infected and dead of that day (For a week)</returns>
        /// GET: api/v1/cases/country/report
        [HttpGet]
        [Route("api/v1/cases/report")]
        public ActionResult<CasesView> GetWeeklyReport() 
        {
            var countryList = _repository.GetCountryList();

            // Key: CountryName, Values: Report List
            var reportList = new Dictionary<string,IEnumerable<ReportView>>();
            
            foreach (var country in countryList)
            {
                var countryReport = _repository.GetWeeklyReport(country.Code);
                reportList.Add(country.Name,countryReport);

            }
            
            return Ok(reportList);
        }
    }
}