using CotecAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CotecAPI.DataAccess.ModelsConfig
{
    public class SmByCountry
    {
        public static void SetEntityBuilder(EntityTypeBuilder<CountrySanitaryMeasures> entityBuilder)
        {   
            // Table Name
            entityBuilder.ToTable("CountrySanitaryMeasures");

            // Primary Key
            entityBuilder.HasKey(c => new{c.CountryCode,c.MeasureId});

            // SM StartDate
            entityBuilder.Property(c => c.StartDate)
                         .HasColumnType("date")
                         .IsRequired();

            // SM EndDate
            entityBuilder.Property(c => c.EndDate)
                         .HasColumnType("date")
                         .IsRequired();

            // SM Description
            entityBuilder.Property(c => c.Status)
                         .HasColumnType("varchar")
                         .HasMaxLength(15)
                         .IsRequired();

            // SM CountryCode
            entityBuilder.Property(c => c.CountryCode)
                         .HasColumnType("varchar")
                         .HasMaxLength(3)
                         .IsRequired();

            // SM MeasureId
            entityBuilder.Property(c => c.MeasureId)
                         .HasColumnType("int")
                         .IsRequired();

            // Foreign Keys
            entityBuilder.HasOne<Country>(c => c.Country)
                         .WithMany(ctry => ctry.ImplementedSanitaryMeasures)
                         .HasForeignKey(c => c.CountryCode);

             entityBuilder.HasOne<SanitaryMeasure>(c => c.Measure)
                         .WithMany(m => m.ImplementedMeasures)
                         .HasForeignKey(c => c.MeasureId);
            

        }
    }
}