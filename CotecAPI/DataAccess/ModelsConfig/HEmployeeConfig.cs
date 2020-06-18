using CotecAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class HEmployeeConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<HospitalEmployee> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("HospitalEmployees");

            // Primary Key
            entityBuilder.HasKey(e => e.Username); 

            // HE Username
            entityBuilder.Property(e => e.Username)
                         .HasColumnType("varchar(20)")
                         .IsRequired();

            // HE Password
            entityBuilder.Property(e => e.Password)
                         .HasColumnType("varchar(20)")
                         .IsRequired();

            // HE Name
            entityBuilder.Property(e => e.Name)
                         .HasColumnType("varchar(20)")
                         .IsRequired();

            // HE LastName
            entityBuilder.Property(e => e.LastName)
                         .HasColumnType("varchar(20)")
                         .IsRequired();

            // HospitalId
            entityBuilder.Property(e => e.Hospital_Id)
                         .HasColumnType("int")
                         .IsRequired();

            // Foreign Key
            entityBuilder.HasOne<Hospital>(e => e.Hospital)
                         .WithMany(h => h.Employees)
                         .HasForeignKey(e => e.Hospital_Id);

        }        
    }
}