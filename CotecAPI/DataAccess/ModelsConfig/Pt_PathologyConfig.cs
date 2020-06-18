using CotecAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class Pt_PathologyConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<PatientPathologies> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("PatientPathologies");

            // Primary Key
            entityBuilder.HasKey(pp => new{pp.PathologyName,pp.PatientDni}); 

            // PatientDni
            entityBuilder.Property(pp => pp.PatientDni)
                         .HasColumnType("varchar")
                         .HasMaxLength(30)
                         .IsRequired();
                        
            // PathologyName
            entityBuilder.Property(pp => pp.PathologyName)
                         .HasColumnType("varchar")
                         .HasMaxLength(50)
                         .IsRequired();

            // Foreign Key
            entityBuilder.HasOne<Patient>(pp => pp.Patient)
                         .WithMany(cp => cp.Pathologies)
                         .HasForeignKey(pp => pp.PatientDni);

            entityBuilder.HasOne<Pathology>(pp => pp.Pathology)
                         .WithMany(p => p.PatientPathologies)
                         .HasForeignKey(pp => pp.PathologyName);

        }
    }
}