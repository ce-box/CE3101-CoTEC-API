using System.Collections.Generic;
using System.Linq;
using CotecAPI.DataAccess.Database;
using CotecAPI.Models.Entities;
using CotecAPI.Models.Views;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CotecAPI.DataAccess.Repositories
{
    public class PatientRepo : IRepository<Patient,PatientView>
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

            _context.Add(patient);

            _context.Database.ExecuteSqlRaw("[NewEvent] @CountryCode={0}, @Type = {1}",patient.Country, "INFECTED");
            
        }

        /**         
         * Delete a patient from the database.
         * @param patient 
         */
        public void Delete(Patient patient)
        {
            _context.Patients.Remove(patient);
        }

        /**         
         * Get a view of all patients registered in the database
         */
        public IEnumerable<PatientView> GetAll(){
            return _context.Set<PatientView>().FromSqlRaw("Select * from [World Patients]").ToList();
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
            string Type;
            switch (patient.Status)
            {
                case 3: Type = "RECOVERED"; break;
                case 4: Type = "DEAD"; break;
                default: return;
            }
            _context.Database.ExecuteSqlRaw("[NewEvent] @CountryCode={0}, @Type = {1}",patient.Country, Type);
        }

    }
}