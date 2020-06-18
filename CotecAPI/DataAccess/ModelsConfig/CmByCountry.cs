using CotecAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class CmByCountry
    {
        public static void SetEntityBuilder(EntityTypeBuilder<CountryContainmemtMeasures> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("CountryContainmemtMeasures");

            // Primary Key
            entityBuilder.HasKey(c => new{c.CountryCode,c.MeasureId});

            // CM StartDate
            entityBuilder.Property(c => c.StartDate)
                         .HasColumnType("date")
                         .IsRequired();

            // CM EndDate
            entityBuilder.Property(c => c.EndDate)
                         .HasColumnType("date")
                         .IsRequired();

            // CM Description
            entityBuilder.Property(c => c.Status)
                         .HasColumnType("varchar")
                         .HasMaxLength(15)
                         .IsRequired();

            // Foreign Keys
            entityBuilder.HasOne<Country>(c => c.Country)
                         .WithMany(ctry => ctry.ImplementedContainmemtMeasures)
                         .HasForeignKey(c => c.CountryCode);

             entityBuilder.HasOne<ContainmentMeasure>(c => c.Measure)
                         .WithMany(m => m.ImplementedMeasures)
                         .HasForeignKey(c => c.MeasureId);
            

        }
    }
}