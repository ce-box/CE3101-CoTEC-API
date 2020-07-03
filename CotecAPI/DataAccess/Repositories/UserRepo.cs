using System.Linq;
using CotecAPI.DataAccess.Database;
using CotecAPI.Models.Entities;

namespace CotecAPI.DataAccess.Repositories
{
    public class UserRepo
    {
        private CotecContext _context;

        public UserRepo(CotecContext context)
        {
            _context = context;
        }

        public Admin GetAdmin(string Username)
        {
            return _context.Admins.FirstOrDefault(ad => ad.Username == Username);
        }

        public HospitalEmployee GetHEmployee(string Username)
        {
            return _context.HEmployees.FirstOrDefault(he => he.Username == Username);
        }

        
    }
}