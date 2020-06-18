using CotecAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class RegionConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Region> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("Regions");

            // Primary Key
            entityBuilder.HasKey(r => new{r.Name,r.CountryCode}); 

            // Region Name
            entityBuilder.Property(r => r.Name)
                         .HasColumnType("varchar(50)")
                         .IsRequired();

            // Region CountryCode
            entityBuilder.Property(r => r.CountryCode)
                         .HasColumnType("varchar(3)")
                         .IsRequired();

            // Foreign Key
            entityBuilder.HasOne<Country>(r => r.Country)
                         .WithMany(ctry => ctry.Regions)
                         .HasForeignKey(r => r.CountryCode);

        }
    }
}