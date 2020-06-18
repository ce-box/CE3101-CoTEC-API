using CotecAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class HospitalConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Hospital> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("Hospitals");

            // Primary Key
            entityBuilder.HasKey(h => h.Id); 

            // HospitalId
            entityBuilder.Property(h => h.Id)
                         .ValueGeneratedOnAdd();

            // Hospital Name
            entityBuilder.Property(h => h.Name)
                         .HasColumnType("varchar(255)")
                         .IsRequired();

            // Hospital ManagerName
            entityBuilder.Property(h => h.ManagerName)
                         .HasColumnType("varchar(60)")
                         .IsRequired();

            // Hospital Phone
            entityBuilder.Property(h => h.Phone)
                         .HasColumnType("varchar(15)")
                         .IsRequired();

            // Hospital Capacity
            entityBuilder.Property(h => h.Capacity)
                         .HasColumnType("int")
                         .IsRequired();

            // Hospital ICU Capacity
            entityBuilder.Property(h => h.ICU_Capacity)
                         .HasColumnType("int")
                         .IsRequired();

            // Region Name
            entityBuilder.Property(h => h.Region)
                         .HasColumnType("varchar(50)")
                         .IsRequired();

            // Country Code
            entityBuilder.Property(h => h.Country)
                         .HasColumnType("varchar(3)")
                         .IsRequired();

            // Foreign Key
            entityBuilder.HasOne<Region>(h => h.HRegion)
                         .WithMany(r=> r.Hospitals)
                         .HasForeignKey(h => new{h.Region,h.Country})
                         .OnDelete(DeleteBehavior.NoAction);

        }
    }
}