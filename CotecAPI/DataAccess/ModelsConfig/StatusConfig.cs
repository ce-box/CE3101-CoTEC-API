using CotecAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class StatusConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<PatientStatus> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("PatientStatus");
            
            // Set Primary Key
            entityBuilder.HasKey(s => s.Id);
            
            // Id
            entityBuilder.Property(s => s.Id)
                         .HasColumnType("int")
                         .ValueGeneratedOnAdd()
                         .IsRequired();

            // Name
            entityBuilder.Property(s => s.Name)
                         .HasColumnType("varchar(20)")
                         .IsRequired();
        }
    }
}