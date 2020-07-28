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
        
        /// <summary>
        /// Obtains all the sanitary measures registered in the database.
        /// </summary>
        /// <returns>List of Sanitary Measures.</returns>
        public IEnumerable<SanitaryMeasure> GetMeasures()
        {
            return _context.S_Measures.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SanitaryMeasure GetMeasureById(int Id)
        {
            return _context.S_Measures.FirstOrDefault(sm => sm.Id == Id);
        }

        /// <summary>
        /// Gets the detail of a measure given its ID.
        /// </summary>
        /// <param name="measureId">Id of the measure.</param>
        /// <param name="countryCode">Country code in alpha-3 format. </param>
        /// <returns>Specified Sanitary Measure.</returns>
        public CountrySanitaryMeasures GetSpecificImplementedCountryMeasure(int measureId, string countryCode)
        {
            return _context.SM_ByCountry.FirstOrDefault(sm => sm.MeasureId == measureId && sm.CountryCode == countryCode);
        }

        /// <summary>
        /// Obtain all the sanitary measures that a country has implemented.
        /// </summary>
        /// <param name="CountryCode">Country code in alpha-3 format. </param>
        /// <returns>List of Sanitary Measures.</returns>
        public IEnumerable<MeasureView> GetCountrySanitaryMeasures([FromQuery] string CountryCode)
        {   
            // TODO: Connect w/DB Context
            // Mock Inf@
            var measures = _context.Set<MeasureView>().FromSqlRaw($"EXEC GetCountryMeasures @countryCode = {CountryCode}").ToList();

            return measures;
        }

        /// <summary>
        /// Get all the sanitary measures that are active in a country.
        /// </summary>
        /// <param name="CountryCode">Country code in alpha-3 format. </param>
        /// <returns>List of Sanitary Measures.</returns>
         public IEnumerable<MeasureView> GetActiveSanitaryMeasuresByCountry([FromQuery] string CountryCode)
        {   
            // TODO: Connect w/DB Context
            // Mock Inf@
            var measures = _context.Set<MeasureView>().FromSqlRaw($"EXEC GetActiveCountryMeasures @countryCode = {CountryCode}").ToList();

            return measures;
        }

        /* -------------------------------------------
                        CREATE METHODS 
           -------------------------------------------*/
        
        /// <summary>
        /// Add a new sanitary measure to the database.
        /// </summary>
        /// <param name="newSanitaryMeasure">Sanitary measure to add.</param>
        public void CreateSanitaryMeasure(SanitaryMeasure newSanitaryMeasure)
        {
            _context.S_Measures.Add(newSanitaryMeasure);
        }

        /// <summary>
        /// Assign a sanitary measure to a country.
        /// </summary>
        /// <param name="countrySanitaryMeasure">Sanitary Measure to be assigned. </param>
        public void AssingSanitaryMeasure(CountrySanitaryMeasures countrySanitaryMeasure)
        {
            _context.SM_ByCountry.Add(countrySanitaryMeasure);
        }

        /* -------------------------------------------
                        DELETE METHODS 
           -------------------------------------------*/
        
        /// <summary>
        /// Delete a sanitary measure from the database.
        /// Warning: It is not removed, but changes the status of all deployments of the measure to inactive.
        /// </summary>
        /// <param name="sanitaryMeasure">Sanitary Measure to delete.</param>
        public void DeleteSanitaryMeasure(SanitaryMeasure sanitaryMeasure)
        {
            _context.S_Measures.Remove(sanitaryMeasure);
        }

        /// <summary>
        /// Eliminates a sanitary measure implementation.
        /// Warning: It does not delete it, but changes its status to inactive.
        /// </summary>
        /// <param name="countrySanitaryMeasure">Implemented measure to delete.</param>
        public void DeleteCountrySanitaryMeasure(CountrySanitaryMeasures countrySanitaryMeasure)
        {
            _context.SM_ByCountry.Remove(countrySanitaryMeasure);
        }

        /* -------------------------------------------
                        UPDATE METHODS 
           -------------------------------------------*/
        
        /// <summary>
        /// Lets you edit an implemented sanitary measure.
        /// </summary>
        /// <param name="countrySanitaryMeasure">Implemented Sanitary Measure to Edit.</param>
        public void UpdateSanitaryMeasure(CountrySanitaryMeasures countrySanitaryMeasure)
        {
            // Nothing
        }

        /// <summary>
        /// Lets you edit a sanitary measure.
        /// </summary>
        /// <param name="sanitaryMeasure">Sanitary Measure to Edit.</param>
        public void UpdateSanitaryMeasure(SanitaryMeasure sanitaryMeasure)
        {
            // Nothing
        }

        /// <summary>
        /// Saves all changes made to the database after a transaction.
        /// </summary>
        /// <returns>True if the changes were saved successfully, false if an error occurs.</returns>
        public bool SaveChanges()
        {
            return ( _context.SaveChanges() >= 0);
        }

    }
}