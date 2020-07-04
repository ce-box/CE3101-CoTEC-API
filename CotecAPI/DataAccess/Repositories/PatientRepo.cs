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

        /**         
         * Create a new patient by adding it to the database. 
         * The admission of a patient creates a new case event in the patient's country.
         * @param patient 
         */
        public void Create(Patient patient)
        {
            if(patient == null)
                throw new System.ArgumentNullException(nameof(patient));

            _context.Patients.Add(patient);
        }

        /**         
         * Create new patiens from a list by adding it to the database. 
         * The admission of a patient creates a new case event in the patient's country.
         * @param patient 
         */
        public void CreatePatients(IEnumerable<Patient> patients)
        {
            if(patients == null)
                throw new System.ArgumentNullException(nameof(patients));

            _context.Patients.AddRange(patients);
        }

        /**         
         * Delete a patient from the database.
         * @param patient 
         */
        public void Delete(string Dni)
        {
            _context.Database.ExecuteSqlRaw($"DELETE FROM Patients WHERE Dni={Dni}");
        }

        /**         
         * Get a view of all registered patients in a hospital
         * @param hospital_Id 
         */
        public IEnumerable<PatientView> GetAll(int hospital_Id)
        {
            var param = new SqlParameter("@Hospital_Id",hospital_Id); 
            var patients =  _context.Set<PatientView>().FromSqlRaw("GetAllPatients @Hospital_Id",param).ToList();
            return patients;
        }
        
        /**         
         * Returns a patient given their ID
         * @param Dni 
         */
        public PatientView GetByDni(string Dni)
        {
            var param = new SqlParameter("@patientDni",Dni); 
            var patient =  _context.Set<PatientView>().FromSqlRaw("PatientSummary @patientDni",param).ToList();
            return patient[0];
        }

        /**         
         * Returns a raw patient given their ID
         * @param Dni 
         */
        public Patient GetByDniRaw(string Dni)
        {
            return _context.Patients.FirstOrDefault(p => p.Dni == Dni);
        }

        /**         
         * Save the changes made to the database
         */
        public bool SaveChanges()
        {
            return ( _context.SaveChanges() >= 0);
        }

        /**         
         * Update properties of a patient. If your status changes to RECOVERED or DEAD, 
         * a new event associated with the patient's country is entered.
         * @param patient 
         */
        public void Update(Patient patient)
        {  
            _context.Patients.Update(patient);
        }

    }
}