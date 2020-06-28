using CotecAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class MedicationConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Medication> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("Medications");

            // Primary Key
            entityBuilder.HasKey(m => m.Id); 

            // HospitalId
            entityBuilder.Property(m => m.Id)
                         .ValueGeneratedOnAdd();

            // Medication Name
            entityBuilder.Property(m => m.Name)
                         .HasColumnType("varchar(60)")
                         .IsRequired();

            // Medication PharmaceuticCo
            entityBuilder.Property(m => m.PharmaceuticCo)
                         .HasColumnType("int")
                         .IsRequired();

            // Foreign Key
            entityBuilder.HasOne<PharmaceuticalCompany>(m => m.PCompany)
                         .WithMany(pc => pc.Madications)
                         .HasForeignKey(m => m.PharmaceuticCo);

        }
    }
}