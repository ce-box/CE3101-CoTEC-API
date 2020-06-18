using CotecAPI.DataAccess.ModelsConfig;
using CotecAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CotecAPI.DataAccess.Database
{
    public class CotecContext : DbContext
    {
        
        public CotecContext(){ }

        public CotecContext(DbContextOptions<CotecContext> opt) : base(opt) { } 

        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<SanitaryMeasure> S_Measures { get; set; }
        public DbSet<ContainmentMeasure> C_Measures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            
            // Geographic Entities
            ContinentConfig.SetEntityBuilder(modelBuilder.Entity<Continent>());
            CountryConfig.SetEntityBuilder(modelBuilder.Entity<Country>());
            RegionConfig.SetEntityBuilder(modelBuilder.Entity<Region>());


            // Users Entities
            AdminConfig.SetEntityBuilder(modelBuilder.Entity<Admin>());

            // Measures Entities
            SanitaryMeasureConfig.SetEntityBuilder(modelBuilder.Entity<SanitaryMeasure>());
            ContainmentMeasureConfig.SetEntityBuilder(modelBuilder.Entity<ContainmentMeasure>());

        }
        
    }
    
}