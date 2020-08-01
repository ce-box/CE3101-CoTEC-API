using System.Collections.Generic;
using System.Linq;
using CotecAPI.DataAccess.Database;
using CotecAPI.Models.Entities;
using CotecAPI.Models.Views;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CotecAPI.DataAccess.Repositories
{
    public class HospitalRepo
    {
        private readonly CotecContext _context;

        public HospitalRepo(CotecContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all the hospitals registered in the database.
        /// </summary>
        /// <returns>Hospital List.</returns>
        public IEnumerable<Hospital> GetAllHospitals()
        {
            return _context.Hospitals.ToList();
        }

        /// <summary>
        /// Get a list of all hospitals in a country.
        /// </summary>
        /// <param name="country">ALPHA-3 country code.</param>
        /// <returns>Hospital List.</returns>
        public IEnumerable<Hospital> GetHospitalsByCountry(string country)
        {
            return _context.Hospitals.Where(h => h.Country == country).ToList();
        }

        /// <summary>
        /// Obtains the data of a hospital given its Id.
        /// </summary>
        /// <param name="Id">Hospital identification code.</param>
        /// <returns>Returns a Hospital object.async </returns>
        public Hospital GetHospitalById(int Id)
        {
            return _context.Hospitals.FirstOrDefault(h => h.Id == Id);
        }

        /// <summary>
        /// Add a hospital to the database.
        /// </summary>
        /// <param name="hosp">Hospital to be added.</param>
        public void CreateHospital(Hospital hosp)
        {
            _context.Hospitals.Add(hosp);
        }

        /// <summary>
        /// Edit the data of a Hospital given its Id.
        /// </summary>
        /// <param name="hosp">Hospital to be edited.</param>
        public void UpdateHospital(Hospital hosp)
        {
            // nothing
        }

        /// <summary>
        /// Delete a hospital from the database.
        /// </summary>
        /// <param name="hosp">Hospital to be deleted.</param>
        public void DeleteHospital(Hospital hosp)
        {
            _context.Hospitals.Remove(hosp);
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