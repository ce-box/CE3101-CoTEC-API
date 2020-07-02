using System.Collections.Generic;
using System.Linq;
using CotecAPI.DataAccess.Database;
using CotecAPI.Models.Entities;
using CotecAPI.Models.Views;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CotecAPI.DataAccess.Repositories
{
    public class PathologyRepo
    {
        private readonly CotecContext _context;

        // Inject the Data Base Context
        public PathologyRepo(CotecContext context)
        {
            _context = context;
        }

        /*--------------------------------
                     PATHOLOGIES     
         *--------------------------------*/
        public void CreatePathology(Pathology ptg)
        {
            _context.Pathologies.Add(ptg);
        }

        public void DeletePathology(Pathology ptg)
        {
            _context.Pathologies.Remove(ptg);
        }

        public Pathology ExistPathology(string name)
        {
            return _context.Pathologies.FirstOrDefault(ptg => ptg.Name == name);
        }

        public IEnumerable<Pathology> GetAll()
        {
            return _context.Pathologies.ToList();
        }

        public void UpdatePathology(Pathology ptg)
        {
            // foo
        }


        /*--------------------------------
                ENTITY PATHOLOGIES     
         *--------------------------------*/
        public IEnumerable<PathologyView> getPatientPathology(string Dni)
        {
            var param = new SqlParameter("@patientDni",Dni); 
            var pathologies = _context.Set<PathologyView>().FromSqlRaw("PatientPathology @patientDni",param).ToList();
            return pathologies;
        }

        public IEnumerable<PathologyView> getContactPathology(string Dni)
        {
            var param = new SqlParameter("@patientDni",Dni); 
            var pathologies = _context.Set<PathologyView>().FromSqlRaw("PatientPathology @patientDni",param).ToList();
            return pathologies;
        }

        public void AssignPatientPathologies(IEnumerable<PatientPathologies> p_pat)
        {
            _context.PatientPathologies.AddRange(p_pat);
        }

        public void AssignContactPathologies(IEnumerable<PersonPathologies> p_pat)
        {
            _context.PersonPathologies.AddRange(p_pat);
        }

        public void DeletePatientPathology(string Dni, string p_name)
        {
            var pathology = _context.PatientPathologies.FirstOrDefault(p => p.PatientDni==Dni && p.PathologyName==p_name);
            _context.PatientPathologies.Remove(pathology);
        }

        public void DeleteContactPathology(string Dni, string p_name)
        {
            var pathology = _context.PersonPathologies.FirstOrDefault(p => p.PersonDni==Dni && p.PathologyName==p_name);
            _context.PersonPathologies.Remove(pathology);
        }

        public bool SaveChanges()
        {
            return ( _context.SaveChanges() >= 0);
        }


    }
}