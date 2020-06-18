using CotecAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class ContinentConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Continent> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("Continents");
            
            // Set Primary Key
            entityBuilder.HasKey(cnt => cnt.Code); //PK
            
            // Continent Code
            entityBuilder.Property(cnt => cnt.Code)
                         .HasColumnType("varchar")
                         .HasMaxLength(3)
                         .IsRequired();
            
            // Continent Name
            entityBuilder.Property(cnt => cnt.Name)
                         .HasColumnType("varchar")
                         .HasMaxLength(15)
                         .IsRequired();
        }


    }
}