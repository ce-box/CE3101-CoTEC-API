using Microsoft.EntityFrameworkCore;

namespace CotecAPI.Data
{
    public class CotecContext : DbContext
    {

        public CotecContext(DbContextOptions<CotecContext> opt) : base(opt) 
        {
            
        } 


        protected override void OnModelCreating(ModelBuilder modelBuilder){

        }

        
    }
    
}