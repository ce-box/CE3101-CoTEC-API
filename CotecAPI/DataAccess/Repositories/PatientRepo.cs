using System.Collections.Generic;
using System.Linq;
using CotecAPI.DataAccess.Database;
using CotecAPI.Models.Entities;
using CotecAPI.Models.Views;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CotecAPI.DataAccess.Repositories
{
    public class PatientRepo
    {
        private readonly CotecContext _context;

        // Inject the Data Base Context
        public PatientRepo(CotecContext context)
        {
            _context = context;
        }


        /* -------------------------------------------
                        CRUD METHODS 
           -------------------------------------------*/

        /// <summary>
        /// reate a new patient by adding it to the database. 
        /// The admission of a patient creates a new case event in the patient's country.
        /// </summary>
        /// <param name="patient"> new Patient.</param>
        public void CreatePatient(Patient patient)
        {
            if(patient == null)
                throw new System.ArgumentNullException(nameof(patient));

            _context.Patients.Add(patient);
        }

         /// <summary>
         /// Create new patiens from a list by adding it to the database. 
         /// The admission of a patient creates a new case event in the patient's country.
         /// </summary>
         /// <param name="patients"> Patients List.</param>
        public void CreatePatients(IEnumerable<Patient> patients)
        {
            if(patients == null)
                throw new System.ArgumentNullException(nameof(patients));

            _context.Patients.AddRange(patients);
        }


        /// <summary>
        /// Delete a patient from the database.
        /// </summary>
        /// <param name="Dni"> Patient Dni.</param>
        public void DeletePatient(string Dni)
        {
            var param = new SqlParameter("@PatientDni",Dni); 
            _context.Database.ExecuteSqlRaw("deletePatient @PatientDni",param);
        }

        /// <summary>
        /// Get a view of all registered patients in a hospital.
        /// </summary>
        /// <param name="hospital_Id"> Hospital Id. </param>
        /// <returns> Patients List. </returns>
        public IEnumerable<PatientView> GetAll(int hospital_Id)
        {
            var param = new SqlParameter("@Hospital_Id",hospital_Id); 
            var patients =  _context.Set<PatientView>().FromSqlRaw("GetAllPatients @Hospital_Id",param).ToList();
            return patients;
        }
        
        /// <summary>
        /// Returns a patient given their ID
        /// </summary>
        /// <param name="Dni">Patient Dni.</param>
        /// <returns>Required Patient.</returns>
        public PatientView GetPatientByDni(string Dni)
        {
            var param = new SqlParameter("@patientDni",Dni); 
            var patient =  _context.Set<PatientView>().FromSqlRaw("PatientSummary @patientDni",param).ToList();
            return patient[0];
        }

        /// <summary>
        /// Returns a raw patient given their Dni.
        /// </summary>
        /// <param name="Dni">Patient Dni.</param>
        /// <returns>Required Patient. </returns>
        public Patient GetPatientByDniRaw(string Dni)
        {
            return _context.Patients.FirstOrDefault(p => p.Dni == Dni);
        }

        /// <summary>
        /// Update properties of a patient. If your status changes to RECOVERED or DEAD, 
        /// a new event associated with the patient's country is entered.
        /// </summary>
        /// <param name="patient"> Patient to Edit</param>
        public void UpdatePatient(Patient patient)
        {  
            _context.Patients.Update(patient);
        }

        /// <summary>
        /// Return all the Countries in the database
        /// </summary>
        /// <returns>Country List</returns>
        public List<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Country"></param>
        /// <returns></returns>
        public List<Region> GetRegions(string Country)
        {
            var regions = _context.Regions.Where(r => r.CountryCode==Country).ToList();
            return regions;
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