using System.Collections.Generic;
using System.Linq;
using CotecAPI.DataAccess.Database;
using CotecAPI.Models.Entities;
using CotecAPI.Models.Views;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CotecAPI.DataAccess.Repositories
{
    public class RegionRepo
    {
        private readonly CotecContext _context;

        public RegionRepo(CotecContext context)
        {
           _context = context;
        }

        public void CreateRegion(Region reg)
        {
            _context.Regions.Add(reg);
        }

        public Region Exist(string name, string c_code)
        {
            return _context.Regions.FirstOrDefault(r => r.Name == name && r.CountryCode == c_code);
        }

        public IEnumerable<Region> GetRegions(string Country)
        {
            var regions = _context.Regions.Where(r => r.CountryCode==Country).ToList();
            return regions;
        }

        public IEnumerable<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public void UpdateRegion(Region reg)
        {
            // NO aplica por diseño
        }


        public void DeleteRegion(Region reg)
        {
            _context.Regions.Remove(reg);
        }

        public bool SaveChanges()
        {
            return ( _context.SaveChanges() >= 0);
        }


    }
}