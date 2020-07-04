using System;
using System.Collections.Generic;
using System.Linq;
using CotecAPI.DataAccess.Database;
using CotecAPI.Models.Entities;
using CotecAPI.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CotecAPI.DataAccess.Repositories
{
    public class MeasuresRepo
    {
         private readonly CotecContext _context;

        // Inject the Data Base Context
        public MeasuresRepo(CotecContext context)
        {
            _context = context;
        }

        /* -------------------------------------------
                           READ METHODS 
           -------------------------------------------*/
        
        public IEnumerable<SanitaryMeasure> GetMeasures()
        {
            return _context.S_Measures.ToList();
        }

        public SanitaryMeasure GetById(int Id)
        {
            return _context.S_Measures.FirstOrDefault(sm => sm.Id == Id);
        }

        public CountrySanitaryMeasures GetById(int m_id, string c_code)
        {
            return _context.SM_ByCountry.FirstOrDefault(sm => sm.MeasureId == m_id && sm.CountryCode == c_code);
        }

        public IEnumerable<MeasureView> GetSanitaryMeasures([FromQuery] string CountryCode)
        {   
            // TODO: Connect w/DB Context
            // Mock Inf@
            var measures = _context.Set<MeasureView>().FromSqlRaw($"EXEC GetCountryMeasures @countryCode = {CountryCode}").ToList();

            return measures;
        }

         public IEnumerable<MeasureView> GetActiveSanitaryMeasures([FromQuery] string CountryCode)
        {   
            // TODO: Connect w/DB Context
            // Mock Inf@
            var measures = _context.Set<MeasureView>().FromSqlRaw($"EXEC GetActiveCountryMeasures @countryCode = {CountryCode}").ToList();

            return measures;
        }

        /* -------------------------------------------
                        CREATE METHODS 
           -------------------------------------------*/

        public void CreateSanitaryMeasure(SanitaryMeasure sm)
        {
            _context.S_Measures.Add(sm);
        }

        public void AssingSanitaryMeasure(CountrySanitaryMeasures csm)
        {
            _context.SM_ByCountry.Add(csm);
        }

        /* -------------------------------------------
                        DELETE METHODS 
           -------------------------------------------*/
        
        public void DeleteSanitaryMeasure(SanitaryMeasure sm)
        {
            _context.S_Measures.Remove(sm);
        }

        public void DeleteCountrySanitaryMeasure(CountrySanitaryMeasures sm)
        {
            _context.SM_ByCountry.Remove(sm);
        }

        /* -------------------------------------------
                        UPDATE METHODS 
           -------------------------------------------*/
        
        public void UpdateSanitaryMeasure(CountrySanitaryMeasures csm)
        {
            // Nothing
        }

        public void UpdateSanitaryMeasure(SanitaryMeasure csm)
        {
            // Nothing
        }

        /**         
         * Save the changes made to the database
         */
        public bool SaveChanges()
        {
            return ( _context.SaveChanges() >= 0);
        }

    }
}