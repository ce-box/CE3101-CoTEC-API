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

        public void CreateMedication(Medication med)
        {
            _context.Medications.Add(med);
        }

        public Medication Exist(int id)
        {
            return _context.Medications.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<MedicationView> GetMedicationList()
        {
            var medications =  _context.Set<MedicationView>().FromSqlRaw("SELECT * FROM GetMedications").ToList();
            return medications;
        }

        public IEnumerable<PharmaceuticalCompany> GetPharmCoList()
        {
            return _context.P_Companies.ToList();
        }

        public void UpdateMedications(Medication med)
        {
            // foo
        }

        public void DeleteMedication(Medication med)
        {
            _context.Medications.Remove(med);
        }

        /*--------------------------------
                ENTITY MEDICATIONS     
         *--------------------------------*/

        public void AssociateMedication(PatientMedications pm)
        {
            _context.PatientMedications.Add(pm);
        }

        public void AssociateMedications(IEnumerable<PatientMedications> pm)
        {
            _context.PatientMedications.AddRange(pm);
        }

        public IEnumerable<PatientMedicationView> GetPatientMedication(string Dni)
        {
            var param = new SqlParameter("@patientDni",Dni); 
            var medications =  _context.Set<PatientMedicationView>().FromSqlRaw("PatientMedication @patientDni",param).ToList();
            return medications;
        }

        public void DeletePatientMedication(string Dni,int MedId)
        {   
            var pm = _context.PatientMedications.FirstOrDefault(pm => pm.PatientDni==Dni && pm.MedicationId==MedId);
            _context.PatientMedications.Remove(pm);
        }

        public bool SaveChanges()
        {
            return ( _context.SaveChanges() >= 0);
        }


    }
}