using CotecAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class P_MedicationConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<PatientMedications> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("PatientMedications");

            // Primary Key
            entityBuilder.HasKey(pm => new{pm.MedicationId,pm.PatientDni}); 

            // Prescription
            entityBuilder.Property(pm => pm.Prescription)
                         .HasColumnType("varchar(255)")
                         .IsRequired();
                        
             // MedicationId
            entityBuilder.Property(pm => pm.MedicationId)
                         .HasColumnType("int")
                         .IsRequired();
            
             // PatientDni
            entityBuilder.Property(pm => pm.PatientDni)
                         .HasColumnType("varchar(30)")
                         .IsRequired();

            // Foreign Key
            entityBuilder.HasOne<Medication>(pm => pm.Medication)
                         .WithMany(m => m.PatientMedications)
                         .HasForeignKey(pm => pm.MedicationId)
                         .OnDelete(DeleteBehavior.NoAction);

            entityBuilder.HasOne<Patient>(pm => pm.Patient)
                         .WithMany(p => p.Medications)
                         .HasForeignKey(pm => pm.PatientDni)
                         .OnDelete(DeleteBehavior.NoAction);

        }
    }
}