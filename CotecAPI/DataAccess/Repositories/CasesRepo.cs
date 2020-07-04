using System.Collections.Generic;
using System.Linq;
using CotecAPI.DataAccess.Database;
using CotecAPI.Models.Views;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CotecAPI.DataAccess.Repositories
{
    public class CasesRepo
    {
        private readonly CotecContext _context;

        // Inject the Data Base Context
        public CasesRepo(CotecContext context)
        {
            _context = context;
        }

        /* -------------------------------------------
                        CASES METHODS 
           -------------------------------------------*/

        public CasesView GetByCode(string code)
        {
            var param = new SqlParameter("@Country",code);
            var country = _context.Set<CasesView>().FromSqlRaw("GetCasesByCountry @Country",param).ToList();
            return country[0];
        }

        public IEnumerable<CasesView> GetAll()
        {
            var countries = _context.Set<CasesView>()
                                    .FromSqlRaw("EXEC GetAllCountriesCases")
                                    .ToList();
            return countries;
        }

        public CasesView GetWorldCases()
        {
            var country = _context.Set<CasesView>().FromSqlRaw("SELECT CountryName, CountryCode, FlagUrl, Infected, Recovered, Deaths, Active, DailyIncrease FROM [World Cases]").ToList();
            return country[0];
        }


    }
}