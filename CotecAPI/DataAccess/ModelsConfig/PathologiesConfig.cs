using CotecAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class PathologiesConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Pathology> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("Pathologies");
            
            // Set Primary Key
            entityBuilder.HasKey(path => path.Name);
            
            // Name
            entityBuilder.Property(path => path.Name)
                         .HasColumnType("varchar(50)")
                         .IsRequired();
            
            // Symptoms
            entityBuilder.Property(path => path.Symptoms)
                         .HasColumnType("varchar(255)")
                         .IsRequired();

            // Description
            entityBuilder.Property(path => path.Description)
                         .HasColumnType("varchar(255)")
                         .IsRequired();
                        
            // Treatment
            entityBuilder.Property(path => path.Treatment)
                         .HasColumnType("varchar(255)")
                         .IsRequired();
        }
    }
}