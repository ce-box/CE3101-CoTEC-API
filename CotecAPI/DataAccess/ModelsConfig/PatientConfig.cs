using CotecAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class PatientConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Patient> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("Patients");

            // Primary Key
            entityBuilder.HasKey(pat => pat.Dni); 

            // Patient Dni
            entityBuilder.Property(pat => pat.Dni)
                         .HasColumnType("varchar")
                         .HasMaxLength(30)
                         .IsRequired();

            // Patient Name
            entityBuilder.Property(pat => pat.Name)
                         .HasColumnType("varchar")
                         .HasMaxLength(20)
                         .IsRequired();

            // Patient LastName
            entityBuilder.Property(pat => pat.LastName)
                         .HasColumnType("varchar")
                         .HasMaxLength(20)
                         .IsRequired();
                        
            // Patient Birth date
            entityBuilder.Property(pat => pat.DoB)
                         .HasColumnType("date")
                         .IsRequired();
                        
            // Patient Hospitalized
            entityBuilder.Property(pat => pat.Hospitalized)
                         .HasColumnType("bit")
                         .IsRequired();

            // Patient ICU
            entityBuilder.Property(pat => pat.ICU)
                         .HasColumnType("bit")
                         .IsRequired();

            // Patient Status
            entityBuilder.Property(pat => pat.Status)
                         .HasColumnType("int")
                         .IsRequired();
                        

            // Patient Hospital_Id
            entityBuilder.Property(pat => pat.Hospital_Id)
                         .HasColumnType("int")
                         .IsRequired();

            // Patient Region
            entityBuilder.Property(pat => pat.Region)
                         .HasColumnType("varchar")
                         .HasMaxLength(50)
                         .IsRequired();

            // Patient Country
            entityBuilder.Property(pat => pat.Country)
                         .HasColumnType("varchar")
                         .HasMaxLength(3)
                         .IsRequired();

            // Foreign Key
            entityBuilder.HasOne<PatientStatus>(pat => pat.PatientStatus)
                         .WithMany(s => s.Patients)
                         .HasForeignKey(pat => pat.Status);
            
            entityBuilder.HasOne<Hospital>(pat => pat.Hospital)
                         .WithMany(h => h.Patients)
                         .HasForeignKey(pat => pat.Hospital_Id);

            entityBuilder.HasOne<Region>(pat => pat.PatientRegion)
                         .WithMany(r => r.Patients)
                         .HasForeignKey(pat => new{pat.Region,pat.Country});

        }
    }
}