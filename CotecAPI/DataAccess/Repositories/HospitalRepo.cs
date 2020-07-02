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

        public IEnumerable<Hospital> GetAll()
        {
            return _context.Hospitals.ToList();
        }

        public IEnumerable<Hospital> GetByCountry(string country)
        {
            return _context.Hospitals.Where(h => h.Country == country).ToList();
        }

        public Hospital getById(int Id)
        {
            return _context.Hospitals.FirstOrDefault(h => h.Id == Id);
        }

        public void CreateHospital(Hospital hosp)
        {
            _context.Hospitals.Add(hosp);
        }

        public void UpdateHospital(Hospital hosp)
        {
            // nothing
        }

        public void DeleteHospital(Hospital hosp)
        {
            _context.Hospitals.Remove(hosp);
        }   

        public bool SaveChanges()
        {
            return ( _context.SaveChanges() >= 0);
        }

    }
}