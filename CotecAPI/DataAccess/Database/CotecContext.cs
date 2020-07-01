using CotecAPI.DataAccess.ModelsConfig;
using CotecAPI.Models.Entities;
using CotecAPI.Models.Views;
using Microsoft.EntityFrameworkCore;

namespace CotecAPI.DataAccess.Database
{
    public class CotecContext : DbContext
    {
        public CotecContext(){ }
        public CotecContext(DbContextOptions<CotecContext> opt) : base(opt) { } 


        // Database Context Objects
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<SanitaryMeasure> S_Measures { get; set; }
        public DbSet<ContainmentMeasure> C_Measures { get; set; }
        public DbSet<CountryContainmentMeasures> CM_ByCountry { get; set; }
        public DbSet<CountrySanitaryMeasures> SM_ByCountry { get; set; }

        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<HospitalEmployee> HEmployees { get; set; }
        public DbSet<Medication> Medications { get; set; }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientMedications> PatientMedications { get; set; }
        public DbSet<PatientPathologies> PatientPathologies { get; set; }
        public DbSet<ContactedPerson> ContactedPersons { get; set; }
        public DbSet<PersonPathologies> PersonPathologies { get; set; }
        public DbSet<PersonsContactedByPatient> ContactedByPacients { get; set; }

        public DbSet<PatientStatus> PatientStatuses { get; set; } 
        public DbSet<PharmaceuticalCompany> P_Companies { get; set; }
        public DbSet<Pathology> Pathologies { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder){
            
            // Geographic Entities
            ContinentConfig.SetEntityBuilder(modelBuilder.Entity<Continent>());
            CountryConfig.SetEntityBuilder(modelBuilder.Entity<Country>());
            RegionConfig.SetEntityBuilder(modelBuilder.Entity<Region>());


            // Administrative Entities
            AdminConfig.SetEntityBuilder(modelBuilder.Entity<Admin>());
            EventConfig.SetEntityBuilder(modelBuilder.Entity<Event>());

            // Measures Entities
            SanitaryMeasureConfig.SetEntityBuilder(modelBuilder.Entity<SanitaryMeasure>());
            ContainmentMeasureConfig.SetEntityBuilder(modelBuilder.Entity<ContainmentMeasure>());
            CmByCountry.SetEntityBuilder(modelBuilder.Entity<CountryContainmentMeasures>());
            SmByCountry.SetEntityBuilder(modelBuilder.Entity<CountrySanitaryMeasures>());

            // Hospital Entities
            HospitalConfig.SetEntityBuilder(modelBuilder.Entity<Hospital>());
            HEmployeeConfig.SetEntityBuilder(modelBuilder.Entity<HospitalEmployee>());
            MedicationConfig.SetEntityBuilder(modelBuilder.Entity<Medication>());

            // Person Entities
            PatientConfig.SetEntityBuilder(modelBuilder.Entity<Patient>());
            P_MedicationConfig.SetEntityBuilder(modelBuilder.Entity<PatientMedications>());
            Pt_PathologyConfig.SetEntityBuilder(modelBuilder.Entity<PatientPathologies>());
            PersonConfig.SetEntityBuilder(modelBuilder.Entity<ContactedPerson>());
            Ps_PathologyConfig.SetEntityBuilder(modelBuilder.Entity<PersonPathologies>());
            ContactsByPatientConfig.SetEntityBuilder(modelBuilder.Entity<PersonsContactedByPatient>());

            // Not related Entities
            PathologiesConfig.SetEntityBuilder(modelBuilder.Entity<Pathology>());
            Pharm_CompanyConfig.SetEntityBuilder(modelBuilder.Entity<PharmaceuticalCompany>());
            StatusConfig.SetEntityBuilder(modelBuilder.Entity<PatientStatus>());

            // Views and Stored Procedures
            modelBuilder.Entity<PatientView>().HasNoKey().ToView(null);
            modelBuilder.Entity<CasesView>().HasNoKey().ToView(null);
            modelBuilder.Entity<MeasureView>().HasNoKey().ToView(null);

        }
        
    }
    
}