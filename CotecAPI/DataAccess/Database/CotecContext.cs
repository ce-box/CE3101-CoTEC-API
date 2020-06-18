using Microsoft.EntityFrameworkCore;

namespace CotecAPI.DataAccess.Database
{
    public class CotecContext : DbContext
    {

        public CotecContext(){ }

        public CotecContext(DbContextOptions<CotecContext> opt) : base(opt) { } 


        protected override void OnModelCreating(ModelBuilder modelBuilder){

        }

        
    }
    
}