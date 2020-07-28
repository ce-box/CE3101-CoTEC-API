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

        /// <summary>
        /// Add a new pathology to the database.
        /// </summary>
        /// <param name="pathology">Pathology to add.</param>
        public void CreatePathology(Pathology pathology)
        {
            _context.Pathologies.Add(pathology);
        }

        /// <summary>
        /// Delete a pathology from the database.
        /// </summary>
        /// <param name="pathology">Pathology to delete.</param>
        public void DeletePathology(Pathology pathology)
        {
            _context.Pathologies.Remove(pathology);
        }

        /// <summary>
        /// Check if a pathology exists in the database.
        /// </summary>
        /// <param name="pathologyName">Pathology name.</param>
        /// <returns></returns>
        public Pathology ExistPathology(string pathologyName)
        {
            return _context.Pathologies.FirstOrDefault(ptg => ptg.Name == pathologyName);
        }

        /// <summary>
        /// Obtains a list of all registered pathologies.
        /// </summary>
        /// <returns>List of pathologies.</returns>
        public IEnumerable<Pathology> GetAllPathologies()
        {
            return _context.Pathologies.ToList();
        }

        /// <summary>
        /// Edit the information of a pathology.
        /// </summary>
        /// <param name="pathology">Pathology to edit.</param>
        public void UpdatePathology(Pathology pathology)
        {
            // nothing
        }


        /*--------------------------------
                ENTITY PATHOLOGIES     
         *--------------------------------*/

        /// <summary>
        /// Obtains all the pathologies associated with a patient.
        /// </summary>
        /// <param name="Dni"> Patient Dni. </param>
        /// <returns>List of pathologies.</returns>
        public IEnumerable<PathologyView> getPatientPathologies(string Dni)
        {
            var param = new SqlParameter("@patientDni",Dni); 
            var pathologies = _context.Set<PathologyView>()
                                      .FromSqlRaw("PatientPathology @patientDni",param)
                                      .ToList();
            return pathologies;
        }

        /// <summary>
        /// Obtains all the pathologies associated with a contacted Person.
        /// </summary>
        /// <param name="Dni"> Person Dni. </param>
        /// <returns>List of pathologies.</returns>
        public IEnumerable<PathologyView> getContactPathologies(string Dni)
        {
            var param = new SqlParameter("@contactDni",Dni); 
            var pathologies = _context.Set<PathologyView>()
                                      .FromSqlRaw("ContactPathology @contactDni",param)
                                      .ToList();
            return pathologies;
        }

        /// <summary>
        /// Assign a pathology to a patient.
        /// </summary>
        /// <param name="patientPathology">Patient pathology to assign.</param>
        public void AssignPatientPathologies(IEnumerable<PatientPathologies> patientPathology)
        {
            _context.PatientPathologies.AddRange(patientPathology);
        }

        /// <summary>
        /// Assign a pathology to a contacted person.
        /// </summary>
        /// <param name="contactPathology">Contact pathology to assign.</param>
        public void AssignContactPathologies(IEnumerable<PersonPathologies> contactPathology)
        {
            _context.PersonPathologies.AddRange(contactPathology);
        }

        /// <summary>
        /// Eliminate a pathology of a patient.
        /// </summary>
        /// <param name="Dni"> Patient Dni. </param>
        /// <param name="pathologyName"> pathology Name. </param>
        public void DeletePatientPathology(string Dni, string pathologyName)
        {
            var pathology = _context.PatientPathologies
                                    .FirstOrDefault(p => p.PatientDni==Dni && 
                                                    p.PathologyName==pathologyName);
            if(pathology != null)
                _context.PatientPathologies.Remove(pathology);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Dni"></param>
        public void DeleteAllPatientPathologies(string Dni)
        {
            var pathologies = _context.PatientPathologies.Where(p => p.PatientDni == Dni).ToList();
            _context.PatientPathologies.RemoveRange(pathologies);
        }

        /// <summary>
        /// Eliminate a pathology of a contacted person.
        /// </summary>
        /// <param name="Dni"> Person Dni. </param>
        /// <param name="pathologyName"> pathology Name. </param>
        public void DeleteContactPathology(string Dni, string pathologyName)
        {
            var pathology = _context.PersonPathologies
                                    .FirstOrDefault(p => p.PersonDni==Dni && 
                                                    p.PathologyName==pathologyName);
            if(pathology != null)                                                    
                _context.PersonPathologies.Remove(pathology);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Dni"></param>
        public void DeleteAllContactPathologies(string Dni)
        {
            var pathologies = _context.PersonPathologies.Where(p => p.PersonDni == Dni).ToList();
            _context.PersonPathologies.RemoveRange(pathologies);
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