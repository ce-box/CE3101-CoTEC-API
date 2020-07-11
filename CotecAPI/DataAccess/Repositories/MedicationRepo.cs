using System.Collections.Generic;
using CotecAPI.DataAccess.Database;
using System.Linq;
using CotecAPI.Models.Entities;
using CotecAPI.Models.Views;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CotecAPI.DataAccess.Repositories
{
    public class MedicationRepo
    {
        private readonly CotecContext _context;

        // Inject the Data Base Context
        public MedicationRepo(CotecContext context)
        {
            _context = context;
        }

        /*--------------------------------
                    MEDICATIONS     
         *--------------------------------*/

        /// <summary>
        /// Add a new medication to the database.
        /// </summary>
        /// <param name="medication">Medicine to be added.</param>
        public void CreateMedication(Medication medication)
        {
            _context.Medications.Add(medication);
        }

        /// <summary>
        /// Check if there is a medicine using its ID.
        /// </summary>
        /// <param name="id">Medication identification code.</param>
        /// <returns>If it finds the medicine it returns it, otherwise it returns null. </returns>
        public Medication ExistMedications(int id)
        {
            return _context.Medications.FirstOrDefault(m => m.Id == id);
        }

        /// <summary>
        /// Get a list of all medications in the database.
        /// </summary>
        /// <returns>Medication List. </returns>
        public IEnumerable<MedicationView> GetMedicationList()
        {
            var medications =  _context.Set<MedicationView>().FromSqlRaw("SELECT * FROM GetMedications").ToList();
            return medications;
        }

        /// <summary>
        /// Get a list of pharmaceutical companies.
        /// </summary>
        /// <returns>List of pharmaceutical companies.</returns>
        public IEnumerable<PharmaceuticalCompany> GetPharmCoList()
        {
            return _context.P_Companies.ToList();
        }

        /// <summary>
        /// Edit the data of a medicine.
        /// </summary>
        /// <param name="medication">Medication to edit.</param>
        public void UpdateMedication(Medication medication)
        {
            // foo
        }

        /// <summary>
        /// Delete a medication from the database.
        /// </summary>
        /// <param name="medication">Medication to delete.</param>
        public void DeleteMedication(Medication medication)
        {
            _context.Medications.Remove(medication);
        }

        /*--------------------------------
                ENTITY MEDICATIONS     
         *--------------------------------*/

        /// <summary>
        /// Assign a medication to a patient, given the patient's Dni.
        /// </summary>
        /// <param name="patientMedication">new patient medication.</param>
        public void AssociateMedication(PatientMedications patientMedication)
        {
            _context.PatientMedications.Add(patientMedication);
        }

        /// <summary>
        /// Assign many medications to a patient, given the patient's Dni.
        /// </summary>
        /// <param name="patientMedicationList">List of medications per patient.</param>
        public void AssociateMedications(IEnumerable<PatientMedications> patientMedicationList)
        {
            _context.PatientMedications.AddRange(patientMedicationList);
        }

        /// <summary>
        /// Get the medications you are assigned a patient, given the patient's Dni.
        /// </summary>
        /// <param name="Dni">Patient identification number.</param>
        /// <returns></returns>
        public IEnumerable<PatientMedicationView> GetPatientMedication(string Dni)
        {
            var param = new SqlParameter("@patientDni",Dni); 
            var medications =  _context.Set<PatientMedicationView>().FromSqlRaw("PatientMedication @patientDni",param).ToList();
            return medications;
        }

        /// <summary>
        /// Edit a medication associated with a patient.
        /// </summary>
        /// <param name="Dni">Patient identification number.</param>
        /// <param name="medicationId">Medicine identification code. </param>
        public void DeletePatientMedication(string Dni,int medicationId)
        {   
            var pm = _context.PatientMedications.FirstOrDefault(pm => pm.PatientDni==Dni && pm.MedicationId==medicationId);
            _context.PatientMedications.Remove(pm);
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