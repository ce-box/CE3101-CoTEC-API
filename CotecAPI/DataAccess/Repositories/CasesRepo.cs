using System.Collections.Generic;
using System.Linq;
using CotecAPI.DataAccess.Database;
using CotecAPI.Models.Entities;
using CotecAPI.Models.Views;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CotecAPI.DataAccess.Repositories
{
    public class CasesRepo
    {
        private readonly CotecContext _context;

        // Injects the Data Base Context
        public CasesRepo(CotecContext context)
        {
            _context = context;
        }

        
        ///<summary>
        /// Returns a report of the cases of a country. 
        /// Total infected, Recovered, Dead and Active, together with the daily increase.
        ///</summary>
        /// <param name="countryCode">Country code in alpha-3 format (ISO 3166).</param>
        /// <returns>Returns a CasesView Object with the information regarding the requested country.</returns>
        public CasesView GetCountryCases(string countryCode)
        {
            var param = new SqlParameter("@Country",countryCode);
            var country = _context.Set<CasesView>()
                                  .FromSqlRaw("GetCasesByCountry @Country",param)
                                  .ToList();
            return country[0];
        }

        /// <summary>
        /// Returns a report of the cases of each country. 
        /// Total infected, Recovered, Dead and Active, together with the daily increase.
        /// </summary>
        /// <returns>Returns a CasesView List with the information</returns>
        public IEnumerable<CasesView> GetAllCountriesReport()
        {
            var countries = _context.Set<CasesView>()
                                    .FromSqlRaw("EXEC GetAllCountriesCases")
                                    .ToList();
            return countries;
        }

        /// <summary>
        /// It generates a report of all the infected, recovered, dead, active and the increase of the day, worldwide.
        /// </summary>
        /// <returns>Returns a CasesView Object with the information.</returns>
        public CasesView GetWorldCases()
        {
            var country = _context.Set<CasesView>()
                                  .FromSqlRaw("SELECT CountryName, CountryCode, FlagUrl, Infected, Recovered, Deaths, Active, DailyIncrease FROM [World Cases]")
                                  .ToList();
            return country[0];
        }

        /// <summary>
        /// Returns only the new cases and deaths of the day and a week ago, from a country.
        /// </summary>
        /// <param name="countryCode">Country code in alpha-3 format (ISO 3166).</param>
        /// <returns>Report View List.</returns>
        public IEnumerable<ReportView> GetWeeklyReport(string countryCode)
        {
            var param = new SqlParameter("@Country", countryCode);
            return _context.Set<ReportView>()
                           .FromSqlRaw("EXEC LastWeekCasesReport @Country",param) 
                           .ToList();
        }
        
        /// <summary>
        /// Get a list of all the countries registered in the Database
        /// </summary>
        /// <returns>Country List</returns>
        public IEnumerable<Country> GetCountryList()
        {
            return _context.Countries.ToList();
        }
    }
}