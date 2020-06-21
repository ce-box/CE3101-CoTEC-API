using System.Collections.Generic;
using System.Linq;
using CotecAPI.DataAccess.Database;
using CotecAPI.Models;
using CotecAPI.Models.Content;
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

        public void Create(Patient patient)
        {
            if(patient == null)
                throw new System.ArgumentNullException(nameof(patient));
            
            _context.Add(patient);
        }

        public void Delete(Patient entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PatientView> GetAll(){
            return _context.Set<PatientView>().FromSqlRaw("Select * from [World Patients]").ToList();
        }
        public IEnumerable<PatientView> GetAll(int hospital_Id)
        {
            var param = new SqlParameter("@Hospital_Id",hospital_Id); 
            var patients =  _context.Set<PatientView>().FromSqlRaw("GetAllPatients @Hospital_Id",param).ToList();
            return patients;
        }

        public PatientView GetByDni(string Dni)
        {
            var param = new SqlParameter("@patientDni",Dni); 
            var patient =  _context.Set<PatientView>().FromSqlRaw("PatientSummary @patientDni",param).ToList();
            return patient[0];
        }

        public bool SaveChanges()
        {
            return ( _context.SaveChanges() >= 0);
        }

        public void Update(Patient entity)
        {
            throw new System.NotImplementedException();
        }
    }
}