using System.Collections.Generic;
using CotecAPI.DataAccess.Database;
using System.Linq;
using CotecAPI.Models.Entities;
using CotecAPI.Models.Views;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CotecAPI.DataAccess.Repositories
{
    public class StatusRepo
    {
        private readonly CotecContext _context;

        public StatusRepo(CotecContext context)
        {
            _context = context;
        }

        public void CreateStatus(PatientStatus ps)
        {
            _context.PatientStatuses.Add(ps);
        }
        
        public IEnumerable<PatientStatus> GetAll()
        {
            var statusList = _context.PatientStatuses.ToList();
            return statusList;
        }

        public PatientStatus Exist(int Id)
        {
            return _context.PatientStatuses.FirstOrDefault(ps => ps.Id == Id);
        }

        public void Update(PatientStatus ps)
        {
            // foo
        }

        public void Delete(PatientStatus ps)
        {
            _context.PatientStatuses.Remove(ps);
        }

        public bool SaveChanges()
        {
            return ( _context.SaveChanges() >= 0);
        }

    }
}